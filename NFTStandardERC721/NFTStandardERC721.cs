using Stratis.SmartContracts;

/// <summary>
/// A sample NFT smart contract implementing the ERC-721 standard
/// https://ethereum.org/en/developers/docs/standards/tokens/erc-721/
/// </summary>
[Deploy]
public class NFTStandardERC721 : SmartContract
{
    /*
        function balanceOf(address _owner) external view returns (uint256);
        function ownerOf(uint256 _tokenId) external view returns (address);
        function transferFrom(address _from, address _to, uint256 _tokenId) external payable;
        function approve(address _approved, uint256 _tokenId) external payable;
        function setApprovalForAll(address _operator, bool _approved) external;
        function getApproved(uint256 _tokenId) external view returns (address);
        function isApprovedForAll(address _owner, address _operator) external view returns (bool);

        Non-Spec functions:
        function mint()
    */

    public struct Exception
    {
        public string Message;
    }

#region Storage

    public Address ContractOwner
    {
        get => PersistentState.GetAddress(nameof(ContractOwner));
        private set => PersistentState.SetAddress(nameof(ContractOwner), value);
    }

    public ulong TotalSupply
    {
        get => this.PersistentState.GetUInt64(nameof(TotalSupply));
        private set => this.PersistentState.SetUInt64(nameof(TotalSupply), value);
    }

    public ulong CurrentTokenCount
    {
        get => this.PersistentState.GetUInt64(nameof(CurrentTokenCount));
        private set => this.PersistentState.SetUInt64(nameof(CurrentTokenCount), value);
    }
    
    public ulong GetTokenBalance(Address owner) 
    {
        return this.PersistentState.GetUInt64($"TokenBalance:{owner}");
    }

    public void SetTokenBalance(Address owner, ulong balance) 
    {
        this.PersistentState.SetUInt64($"TokenBalance:{owner}", balance);
    }

    public Address GetTokenOwner(ulong tokenId) 
    {
        return this.PersistentState.GetAddress($"TokenOwner:{tokenId}");
    }

    public void SetTokenOwner(ulong tokenId, Address owner) 
    {
        this.PersistentState.SetAddress($"TokenOwner:{tokenId}", owner);
    }

    public string GetTokenProperties(ulong tokenId) 
    {
        return this.PersistentState.GetString($"TokenProperties:{tokenId}");
    }
    public void SetTokenProperties(ulong tokenId, string properties) 
    {
        this.PersistentState.SetString($"TokenProperties:{tokenId}", properties);
    }

    public OwnerTokens GetOwnerTokens(Address owner)
    {
        return this.PersistentState.GetStruct<OwnerTokens>($"OwnerTokens:{owner}");
    }

    private void SetOwnerTokens(Address owner, OwnerTokens tokens)
    {
        this.PersistentState.SetStruct($"OwnerTokens:{owner}", tokens);
    }

#endregion

    public NFTStandardERC721(ISmartContractState smartContractState)
        : base(smartContractState)
    {
        this.ContractOwner = Message.Sender;
        this.TotalSupply = 10000;
        this.CurrentTokenCount = 0;
    }

#region ERC-721 Functions

    public ulong BalanceOf(Address address)
    {
        return GetTokenBalance(address);
    }

    public Address OwnerOf(ulong tokenId)
    {
        return GetTokenOwner(tokenId);
    }

    public void TransferFrom(Address from, Address to, ulong tokenId)
    {
        // Check that caller is owner of the token
        Address tokenOwner = GetTokenOwner(tokenId);
        Assert(Message.Sender == from && from == tokenOwner);

        // Do ownership update if transferred to other address
        if (from != to)
        {
            // Assign the token to the new owner
            SetTokenOwner(tokenId, to);

            // Update token owners balances
            SetTokenBalance(from, GetTokenBalance(from) - 1);
            SetTokenBalance(to, GetTokenBalance(to) + 1);

            // Update owner's tokens
            RemoveOwnerToken(from, tokenId);
            AddOwnerToken(to, tokenId);
        }
    }

    // For a sample contract we won't implement the following ERC-721 functions
    // function approve(address _approved, uint256 _tokenId) external payable;
    // function setApprovalForAll(address _operator, bool _approved) external;
    // function getApproved(uint256 _tokenId) external view returns (address);
    // function isApprovedForAll(address _owner, address _operator) external view returns (bool);

#endregion

#region Custom NFT Functions

    public void Mint(string properties)
    {
        ulong tokenCount = this.CurrentTokenCount + 1;
        ulong tokenId = tokenCount;

        // Check if token count already exceed total supply
        if (tokenCount > this.TotalSupply) {
            Log(new Exception(){ Message = "All tokens already minted" });
            return;
        }

        // Update current token count
        this.CurrentTokenCount = tokenCount;

        // Assign token to owner
        SetTokenOwner(tokenId, Message.Sender);

        // Add token properties
        SetTokenProperties(tokenId, properties);

        // Update owner's token balance
        SetTokenBalance(Message.Sender, GetTokenBalance(Message.Sender) + 1);

        // Update owner's tokens
        AddOwnerToken(Message.Sender, tokenId);
    }

    public string GetTokensOfAsString(Address owner) 
    {
        string result = "[";

        OwnerTokens ownerTokens = GetOwnerTokens(owner);
        for (int i = 0; i < ownerTokens.TokenIds.Length; i++)
        {
            result += "\"" + ownerTokens.TokenIds[i] + "\"";
        }

        result += "]";

        return result;
    }

#endregion

#region Utility

    private void AddOwnerToken(Address owner, ulong tokenId) 
    {
        OwnerTokens ownerTokens = GetOwnerTokens(owner);
        if (ownerTokens.TokenIds is null || ownerTokens.TokenIds.Length == 0) 
        {
            ownerTokens = new OwnerTokens();
            ownerTokens.TokenIds = new ulong[1];
            ownerTokens.TokenIds[0] = tokenId;
            SetOwnerTokens(owner, ownerTokens);
        } 
        else 
        {
            OwnerTokens updatedTokenOwners = new OwnerTokens();
            updatedTokenOwners.TokenIds = new ulong[ownerTokens.TokenIds.Length + 1];

            for (int i=0; i< ownerTokens.TokenIds.Length; i++) 
            {
                updatedTokenOwners.TokenIds[i] = ownerTokens.TokenIds[i];
            }

            updatedTokenOwners.TokenIds[ownerTokens.TokenIds.Length] = tokenId;
            
            SetOwnerTokens(owner, updatedTokenOwners);
        }
    }

    private void RemoveOwnerToken(Address owner, ulong tokenId) 
    {
        OwnerTokens ownerTokens = GetOwnerTokens(owner);
        if (!(ownerTokens.TokenIds is null) && ownerTokens.TokenIds.Length > 0) 
        {
            OwnerTokens updatedOwnerTokens = new OwnerTokens();
            if (ownerTokens.TokenIds.Length > 1) 
            {
                updatedOwnerTokens.TokenIds = new ulong[ownerTokens.TokenIds.Length - 1];

                int index = 0;
                for (int i=0; i< ownerTokens.TokenIds.Length; i++) 
                {
                    if (ownerTokens.TokenIds[i] != tokenId)
                    {
                        updatedOwnerTokens.TokenIds[index] = ownerTokens.TokenIds[i];
                        index++;
                    }
                }
            }

            this.SetOwnerTokens(owner, updatedOwnerTokens);
        }
    }

#endregion

#region Structs

    public struct OwnerTokens
    {
        public ulong[] TokenIds;
    }

#endregion
}
