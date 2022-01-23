using Stratis.SmartContracts;

/// <summary>
/// The NFT Exchange smart contract which supports exchange of ERC-721 NFTs
/// </summary>
[Deploy]
public class NFTExchange : SmartContract
{
    
#region Storage

    public Address ContractOwner
    {
        get => PersistentState.GetAddress(nameof(ContractOwner));
        private set => PersistentState.SetAddress(nameof(ContractOwner), value);
    }

    public ulong CurrentListingId
    {
        get => this.PersistentState.GetUInt64(nameof(CurrentListingId));
        private set => this.PersistentState.SetUInt64(nameof(CurrentListingId), value);
    }
    
    public ulong CurrentOfferId
    {
        get => this.PersistentState.GetUInt64(nameof(CurrentOfferId));
        private set => this.PersistentState.SetUInt64(nameof(CurrentOfferId), value);
    }

    private void SetListing(Address contract, ulong tokenId, ListingInfo listing)
    {
        this.PersistentState.SetStruct($"Listing:{contract}:{tokenId}", listing);
    }

    public ListingInfo GetListing(Address contract, ulong tokenId)
    {
        return this.PersistentState.GetStruct<ListingInfo>($"Listing:{contract}:{tokenId}");
    }

    private void SetOffer(Address contract, ulong tokenId, OfferInfo offer)
    {
        this.PersistentState.SetStruct($"Offer:{contract}:{tokenId}", offer);
    }

    public OfferInfo GetOffer(Address contract, ulong tokenId)
    {
        return this.PersistentState.GetStruct<OfferInfo>($"Offer:{contract}:{tokenId}");
    }

#endregion

    public NFTExchange(ISmartContractState smartContractState)
        : base(smartContractState)
    {
        this.ContractOwner = Message.Sender;
        this.CurrentListingId = 0;
        this.CurrentOfferId = 0;
    }

    // WIP: Currently, the token owner would have to transfer the token to the exchange contract and 
    // then invoke this function until the OnTokenReceive function is implemented
    public void CreateListing(Address contract, ulong tokenId)
    {
        // Generate new listing ID
        ulong listingID = GenerateNewListingID();

        // Verify that the exchange contract is the owner of the token
        Assert(ContractOwner == GetTokenOwner(contract, tokenId), "The exchange contract is not owner of the token.");

        // Verify that listing token is not already listed
        var listing = GetListing(contract, tokenId);
        Assert(!listing.IsActive, "The token is already on listing.");

        // Create the listing record
        listing = new ListingInfo
        {
            ListingID = listingID,
            Seller = Message.Sender,
            Contract = contract,
            TokenId = tokenId,
            IsActive = true
        };
        SetListing(contract, tokenId, listing);

        Log(new LogMessage { Action = "AcceptOffer", Message = "Successfully created listing" });
    }

    // WIP: Currently, the token owner would have to transfer the token to the exchange contract and 
    // then invoke this function until the OnTokenReceive function is implemented
    public void MakeOffer(Address contract, ulong tokenId, Address listingContract, ulong listingTokenId)
    {
        // Generate new offer ID
        ulong offerID = GenerateNewOfferID();

        // Verify that the exchange contract is the owner of the token
        Assert(ContractOwner == GetTokenOwner(contract, tokenId), "The exchange contract is not owner of the token.");

        // Verify that the listing token is actually listed
        var listing = GetListing(listingContract, listingTokenId);
        Assert(listing.IsActive, "The selling token is not listed.");

        // Verify that offering token is not already on offer
        var offer = GetOffer(contract, tokenId);
        Assert(!offer.IsActive, "The offering token is already on offer.");

        // Create the offer record
        offer = new OfferInfo
        {
            OfferID = offerID,
            Offerer = Message.Sender,
            Contract = contract,
            TokenId = tokenId,
            ListingContract = listingContract,
            ListingTokenId = listingTokenId,
            IsActive = true,
        };
        SetOffer(contract, tokenId, offer);

        Log(new LogMessage { Action = "AcceptOffer", Message = "Successfully created offer" });
    }

    public void AcceptOffer(Address contract, ulong tokenId)
    {
        // Verify that the token is actually on offer
        var offer = GetOffer(contract, tokenId);
        Assert(offer.IsActive, "The offer is not available.");

        // Verify that caller is seller of listing
        var listing = GetListing(offer.ListingContract, offer.ListingTokenId);
        Assert(Message.Sender == listing.Seller, "Caller is not the seller of this listing.");

        // Transfer the offer token to the listing seller
        TransferToken(offer.Contract, offer.TokenId, ContractOwner, listing.Seller);

        // Transfer the listing token to the offerer
        TransferToken(listing.Contract, listing.TokenId, ContractOwner, offer.Offerer);

        // Update listing status
        listing.IsActive = false;
        SetListing(listing.Contract, listing.TokenId, listing);

        // Update offer status
        offer.IsActive = false;
        SetOffer(offer.Contract, offer.TokenId, offer);

        Log(new LogMessage { Action = "AcceptOffer", Message = "Successfully accepted offer" });
    }

    public void CancelOffer(Address contract, ulong tokenId)
    {
        // Verify that the token is actually on offer
        var offer = GetOffer(contract, tokenId);
        Assert(offer.IsActive, "The offer is not available.");

        // Verify that caller is offerer
        Assert(Message.Sender == offer.Offerer, "Caller is not the offerer of this offer.");

        // Refund the offerred token
        TransferToken(offer.Contract, offer.TokenId, ContractOwner, offer.Offerer);
        
        // Update offer status
        offer.IsActive = false;
        SetOffer(offer.Contract, offer.TokenId, offer);

        Log(new LogMessage { Action = "CancelOffer", Message = "Successfully cancelled offer" });
    }

    public void CancelListing(Address contract, ulong tokenId)
    {
        // Verify that the token is actually on listing
        var listing = GetListing(contract, tokenId);
        Assert(listing.IsActive, "The listing is not available.");

        // Verify that caller is seller of listing
        Assert(Message.Sender == listing.Seller, "Caller is not the seller of this listing.");

        // Refund the offerred token
        TransferToken(listing.Contract, listing.TokenId, ContractOwner, listing.Seller);
        
        // Update offer status
        listing.IsActive = false;
        SetListing(listing.Contract, listing.TokenId, listing);

        Log(new LogMessage { Action = "CancelListing", Message = "Successfully cancelled listing" });
    }

    private ulong GenerateNewListingID()
    {
        ulong newId = this.CurrentListingId + 1;
        this.CurrentListingId = newId;
        return newId;
    }

    private ulong GenerateNewOfferID()
    {
        ulong newId = this.CurrentOfferId + 1;
        this.CurrentOfferId = newId;
        return newId;
    }

    private void TransferToken(Address contract, ulong tokenId, Address from, Address to)
    {
        var result = Call(contract, 0, "TransferFrom", new object[] { from, to, tokenId });

        Assert(result.Success, "Failed to invoke TransferFrom on token contract.");
    }

    private Address GetTokenOwner(Address contract, ulong tokenId)
    {
        var result = Call(contract, 0, "OwnerOf", new object[] { tokenId });

        Assert(result.Success && result.ReturnValue is Address, "Failed to invoke OwnerOf on token contract.");

        return (Address)result.ReturnValue;
    }

#region Structs

    public struct LogMessage
    {
        public string Action;
        public string Message;
    }

    public struct ListingInfo
    {
        public ulong ListingID;
        public Address Seller;
        public Address Contract;
        public ulong TokenId;
        public bool IsActive;
    }

    public struct OfferInfo
    {
        public ulong OfferID;
        public Address Offerer;
        public Address Contract;
        public ulong TokenId;
        public Address ListingContract;
        public ulong ListingTokenId;
        public bool IsActive;
    }

#endregion
}
