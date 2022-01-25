# NFT *Exchange*

#### Discover and trade amazing NFTs

NFT Exchange lets you swap your NFT with any other NFT. The platform provides a safe and decentralized avenue for owners to put up their token for trade where other owners can browse and offer their own token in exchange. If the offer is accepted, the exchange takes place.

**Contents**

- [Features](#features)
- [Process Process](#process-process)
- [Technologies](#technologies)
- [Live Product Preview](#technologies)
    - [Developer Quick Start](#developer-quick-start)
    - [Building the contracts](#building-the-contracts)
    - [Running local chain](#running-local-chain)
    - [Deploying the contracts](#deploying-the-contracts)
- [Interacting With the Contracts](#interacting-with-the-contracts)
    - [NFT Exchange Contract functions](#nft-exchange-contract-functions)
    - [NFT Sample Contract functions](#nft-sample-contract-functions)
- [Demo Screenshots](#demo-screenshots)
- [License](#license)

## Features

- Interactive user interface accessible from any device with a web browser
- Put NFT up for trade by creating a listin, with option to write what you're looking for in the listing
- Browse other listings to discover interesting NFTs
- See an NFT you like? Offer up an NFT to exchange for it
- Manage your listings and offers with a single click.

## Process Flow

<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/notai-web/main/docs/images/notai_payment_process.png" alt="Process">
</p>

1. Seller transfers their NFT to exchange contract for listing.
2. Exchange contract creates a listing record tied to the receiving NFT and the seller address.
3. Buyer transfers their NFT to exchange contract as offer to a listing.
4. Exchange contract creates an offer record tied to the receiving offer NFT and the owner address, along with the selling NFT the offer is intended for.
5. If seller accepts the offer: Exchange contract transfers the offering NFT to the seller and the selling NFT to the offerer, and mark both listing and offer as completed.
6. If buyer cancels an offer, the offered NFT is transfered back to the buyer and the offer status is invalidated.
6. If seller cancels a listing, the listed NFT is transfered back to the seller and the listing status is invalidated. For offers to this listing, the buyer can cancel the offer to reclaim their NFT.

## Technologies

**Frontend Application (UX)**

- The front end web application is developed in React with NextJS framework.

**Blockchain Smart Contract**

- **NFT Sample Contract**: Stratis Smart Contract writen in C# representing a sample NFT implementing the [ERC-721 standard](https://ethereum.org/en/developers/docs/standards/tokens/erc-721/). This contract is used to create dummy NFT for development, testing and demo.

- **NFT Exchange Contract**: Stratis Smart Contract writen in C# of the actual NFT Exchange contract. This contract is responsible for all manner of the NFT Exchange. See [NFT Exchange Contract functions](#nft-exchange-contract-functions) for functions.

## Live Product Preview

The alpha preview of the application is available online and is supported by an offchain database.

> While the web frontend is still in early stages of development and will change, the actual Smart Contract itself in this repository is near its final form.

<a href="https://nftexchange.vercel.app" target="_blank">https://nftexchange.vercel.app</a>

## Developer Quick Start

Exchange Contract Hash & ByteCode:
```
Hash
fb33e04f4698dd6f4d5cad7a1ee364eb985273c18b43c3071d2b4b33ced5fdb1

ByteCode
4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C010200A82CB0CC0000000000000000E00022200B013000001000000002000000000000CA2F0000002000000040000000000010002000000002000004000000000000000400000000000000006000000002000000000000030040850000100000100000000010000010000000000000100000000000000000000000782F00004F000000000000000000000000000000000000000000000000000000004000000C0000005C2F00001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E74657874000000D00F0000002000000010000000020000000000000000000000000000200000602E72656C6F6300000C000000004000000002000000120000000000000000000000000000400000420000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000AC2F000000000000480000000200050088240000D40A000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004602280500000A72010000706F0600000A2A4A02280500000A7201000070036F0700000A2A4602280500000A721D0000706F0800000A2A4A02280500000A721D000070036F0900000A2A4602280500000A72350000706F0800000A2A4A02280500000A7235000070036F0900000A2A7202280500000A7259000070038C07000001280A00000A6F0800000A2A7602280500000A7259000070038C07000001280A00000A046F0900000A2A7202280500000A727B000070038C0D000001280A00000A6F0600000A2A7602280500000A727B000070038C0D000001280A00000A046F0700000A2A7202280500000A7299000070038C0D000001280A00000A6F0B00000A2A7602280500000A7299000070038C0D000001280A00000A046F0C00000A2A7202280500000A72C3000070038C07000001280A00000A6F0100002B2A7602280500000A72C3000070038C07000001280A00000A046F0200002B2AB60203280F00000A0202281000000A6F1100000A28020000060220102700006A280400000602166A28060000062A22020328070000062A22020328090000062A00133004007400000001000011020528090000060A0202281000000A6F1100000A03281200000A2C090306281200000A2B011672E5000070281300000A0304281400000A2C3A020504280A000006020302032807000006176ADB2808000006020402042807000006176AD72808000006020305281600000602040528150000062A133004008A00000002000011022805000006176AD70A060B06022803000006361C021202FE1503000002120272030100707D0100000408280300002B2A02062806000006020702281000000A6F1100000A280A000006020703280C0000060202281000000A6F1100000A0202281000000A6F1100000A2807000006176AD728080000060202281000000A6F1100000A0728150000062A0000133005005F0000000300001172370100700A0203280D0000060B160C2B341A8D0C000001251606A22517723B010070A22518077B0200000408968C0D000001A22519723B010070A2281600000A0A0817D60C08077B020000048E6932C1067237010070281700000A0A062A001330040094000000040000110203280D0000060A067B020000048E2D271200FE15040000021200178D0D0000017D02000004067B0200000416049F020306280E0000062A1201FE15040000021201067B020000048E6917D68D0D0000017D02000004160C2B14077B0200000408067B0200000408969F0817D60C08067B020000048E6932E1077B02000004067B020000048E6917D6049F020307280E0000062A133004006C000000050000110203280D0000060A067B020000048E2C5A1201FE15040000021201067B020000048E6917DA8D0D0000017D02000004160C160D2B23067B020000040996042E14077B0200000408067B0200000409969F0817D60C0917D60D09067B020000048E6932D2020307280E0000062A42534A4201000100000000000C00000076342E302E33303331390000000005006C0000000C040000237E000078040000B803000023537472696E67730000000030080000400100002355530070090000100000002347554944000000800900005401000023426C6F6200000000000000020000015715A201090A000000FA013300160000010000000E0000000400000002000000160000001B00000017000000040000000500000001000000030000000600000001000000020000000200000003000000000088010100000000000600F60052020600260152020600E20036020F00720200000A001601F5020A001A03F5020A00E502F5020A009600F50206008C009A010A00BD00F50206007D019A01060028039A01060020009A010A007700F502000000002700000000000100010001001000010000001900010001000A011000D20100002500010017000A011000C402000025000200170006008400B50006004902B800502000000000860806025D00010062200000000081081802BC00010075200000000086087B03C200020087200000000081088B03C60002009A200000000086084803C2000300AC200000000081085E03C6000300BF200000000086004F00CB000400DC200000000086005F00D1000500FA20000000008600EA01D80007001721000000008600F801DE00080035210000000086008102E5000A0052210000000086009402EA000B007021000000008600B202F0000D008D21000000008100C102F7000E00AB21000000008618300252001000D9210000000086004A01CB001100E2210000000086005401D8001200EC21000000008600A101FF0013006C2200000000860043030801160004230000000086005C010D0117007023000000008100B301D10018001024000000008100C101D1001A00000001004401000001004401000001004401000001002A02000001002A02000002006F00000001004700000001004700000002002A0200000100470000000100470000000200A702000001002A02000001002A0200000200D00200000100AA0000000100ED0200000100470000000100AE0100000200DC0100000300470000000100A702000001002A02000001002A02000002004700000001002A02000002004700090030020100110030020600190030020A002900300206003100CE0010005100D70215005100E2021B0051001300220051001D002700590013032D0051007001330051007A01380051002F033E00510039034A003100300252003100800058007100DF015D0039009B036700310074036F003900A7036700310084017C0059000C038F0059000C0395002E000B001C012E00130025012E001B004401430023004D016200750088009B00A3000200010000001C02130100008F0318010000620318010200010003000100020003000200030005000100040005000200050007000100060007000480000000000000000000000000000000001A030000040000000000000000000000AC003000000000000200000000000000000000000000F5020000000003000200040002001B0045001D0045002B00830000000000004E46545374616E646172644552433732310047657455496E7436340053657455496E743634003C4D6F64756C653E0053797374656D2E507269766174652E436F72654C696200746F6B656E496400476574546F6B656E42616C616E636500536574546F6B656E42616C616E63650062616C616E636500494D657373616765006765745F4D6573736167650056616C7565547970650049536D617274436F6E7472616374537461746500736D617274436F6E74726163745374617465004950657273697374656E745374617465006765745F50657273697374656E7453746174650044656275676761626C6541747472696275746500436F6D70696C6174696F6E52656C61786174696F6E73417474726962757465004465706C6F794174747269627574650052756E74696D65436F6D7061746962696C6974794174747269627574650076616C75650042616C616E63654F66004F776E65724F6600476574546F6B656E734F664173537472696E6700476574537472696E6700536574537472696E67004C6F6700536D617274436F6E74726163742E646C6C0053797374656D005472616E7366657246726F6D0066726F6D004164644F776E6572546F6B656E0052656D6F76654F776E6572546F6B656E00457863657074696F6E00746F006765745F53656E64657200476574546F6B656E4F776E657200536574546F6B656E4F776E6572006765745F436F6E74726163744F776E6572007365745F436F6E74726163744F776E6572006F776E6572002E63746F720053797374656D2E446961676E6F737469637300546F6B656E4964730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300446562756767696E674D6F64657300476574546F6B656E50726F7065727469657300536574546F6B656E50726F706572746965730070726F70657274696573004765744F776E6572546F6B656E73005365744F776E6572546F6B656E7300746F6B656E7300476574416464726573730053657441646472657373006164647265737300537472617469732E536D617274436F6E74726163747300436F6E63617400466F726D617400536D617274436F6E7472616374004F626A6563740047657453747275637400536574537472756374004D696E74006765745F43757272656E74546F6B656E436F756E74007365745F43757272656E74546F6B656E436F756E7400417373657274006765745F546F74616C537570706C79007365745F546F74616C537570706C79006F705F457175616C697479006F705F496E657175616C69747900000000001B43006F006E00740072006100630074004F0077006E0065007200001754006F00740061006C0053007500700070006C0079000023430075007200720065006E00740054006F006B0065006E0043006F0075006E007400002154006F006B0065006E00420061006C0061006E00630065003A007B0030007D00001D54006F006B0065006E004F0077006E00650072003A007B0030007D00002954006F006B0065006E00500072006F0070006500720074006900650073005F003A007B0030007D0000214F0077006E006500720054006F006B0065006E0073005F003A007B0030007D00001D41007300730065007200740020006600610069006C00650064002E00003341006C006C00200074006F006B0065006E007300200061006C007200650061006400790020006D0069006E0074006500640000035B0000032200000013612A27CBA99D439BAB130F3104BE9C000420010108032000010520010111110420001229052001111D0E062002010E111D0420010B0E052002010E0B0500020E0E1C0420010E0E052002010E0E063001011E000E040A01111007300102010E1E000520010112210420001239042000111D040701111D07000202111D111D05200201020E0607030B0B110C06300101011E00040A01110C0607030E1110080500010E1D1C0500020E0E0E0707031110111008080704111011100808087CEC85D7BEA7798E02060E03061D0B05200101111D0320000B042001010B0520010B111D06200201111D0B052001111D0B062002010B111D0420010E0B052002010B0E0620011110111D07200201111D111008200301111D111D0B042001010E0520010E111D042800111D0328000B0801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F7773010801000200000000000401000000000000000000000000000000000010000000000000000000000000000000A02F00000000000000000000BA2F0000002000000000000000000000000000000000000000000000AC2F0000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF2500200010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000CC3F00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
```

NFT Contract Hash & ByteCode:
```
Hash
5d77a5cc6e7b72e8cc304efeeb13874b03a1fead54df23abd94c3605ebf43357

ByteCode
4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C010200FDE27D8D0000000000000000E00022200B0130000018000000020000000000003E360000002000000040000000000010002000000002000004000000000000000400000000000000006000000002000000000000030040850000100000100000000010000010000000000000100000000000000000000000EC3500004F000000000000000000000000000000000000000000000000000000004000000C000000D03500001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E7465787400000044160000002000000018000000020000000000000000000000000000200000602E72656C6F6300000C0000000040000000020000001A00000000000000000000000000004000004200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002036000000000000480000000200050050260000800F000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004602280500000A72010000706F0600000A2A4A02280500000A7201000070036F0700000A2A4602280500000A721D0000706F0800000A2A4A02280500000A721D000070036F0900000A2A4602280500000A723F0000706F0800000A2A4A02280500000A723F000070036F0900000A2A8E02280500000A725D000070038C07000001048C0C000001280A00000A056F0100002B2A8A02280500000A725D000070038C07000001048C0C000001280A00000A6F0200002B2A8E02280500000A727D000070038C07000001048C0C000001280A00000A056F0300002B2A8A02280500000A727D000070038C07000001048C0C000001280A00000A6F0400002B2AA60203280D00000A0202280E00000A6F0F00000A280200000602166A280400000602166A28060000062A0013300500AF000000010000110228110000060A020228010000060203042814000006281000000A7299000070281100000A02030428080000060B02077B0700000416FE0172FB000070281100000A1202FE15040000021202067D03000004120202280E00000A6F0F00000A7D040000041202037D050000041202047D060000041202177D07000004080B020304072807000006021203FE15030000021203723D0100707D01000004120372550100707D0200000409280500002B2A0013300500DC000000020000110228120000060A020228010000060203042814000006281000000A7299000070281100000A02050E0428080000060B02077B07000004728F010070281100000A020304280A0000060C02087B0E00000416FE0172D1010070281100000A1203FE15050000021203067D08000004120302280E00000A6F0F00000A7D090000041203037D0A0000041203047D0B0000041203057D0C00000412030E047D0D0000041203177D0E000004090C020304082809000006021204FE15030000021204723D0100707D01000004120472210200707D020000041104280500002B2A13300500E800000003000011020304280A0000060A02067B0E0000047257020070281100000A02067B0C000004067B0D00000428080000060B0202280E00000A6F0F00000A077B04000004281000000A728F020070281100000A02067B0A000004067B0B000004022801000006077B04000004281300000602077B05000004077B06000004022801000006067B0900000428130000061201167D0700000402077B05000004077B060000040728070000061200167D0E00000402067B0A000004067B0B000004062809000006021202FE15030000021202723D0100707D01000004120272E30200707D0200000408280500002B2A133005009C00000004000011020304280A0000060A02067B0E0000047257020070281100000A0202280E00000A6F0F00000A067B09000004281000000A721B030070281100000A02067B0A000004067B0B000004022801000006067B0900000428130000061200167D0E00000402067B0A000004067B0B000004062809000006021201FE15030000021201726D0300707D01000004120172850300707D0200000407280500002B2A133005009C0000000500001102030428080000060A02067B0700000472BF030070281100000A0202280E00000A6F0F00000A067B04000004281000000A728F020070281100000A02067B05000004067B06000004022801000006067B0400000428130000061200167D0700000402067B05000004067B06000004062807000006021201FE1503000002120172FB0300707D01000004120172170400707D0200000407280500002B2A133002001300000006000011022803000006176AD70A02062804000006062A00133002001300000006000011022805000006176AD70A02062806000006062A001330080045000000070000110203166A7255040070198D0E0000012516058C07000001A225170E048C07000001A22518048C0C000001A2166A281300000A0A02066F1400000A726F040070281100000A2A0000001330080050000000070000110203166A72D1040070178D0E0000012516048C0C000001A2166A281300000A0A02066F1400000A2C10066F1500000A750700000114FE032B011672E1040070281100000A066F1500000AA5070000012A42534A4201000100000000000C00000076342E302E33303331390000000005006C0000006C040000237E0000D8040000F003000023537472696E677300000000C80800003C05000023555300040E0000100000002347554944000000140E00006C01000023426C6F6200000000000000020000015715A201090A000000FA013300160000010000000F000000050000000E00000014000000200000001500000004000000070000000100000003000000060000000100000002000000030000000500000000002002010000000000060069010B03060099010B0306005501F8020F002B0300000A0089015C030A009A035C030A0054035C030A0009015C030A00CC035C030600FF0032020A0030015C0306000E0032020600D60132020600B10332020A00D3005C03000000001500000000000100010001001000F30000001900010001000A011000E80000002900010015000A011000530200002900030015000A0110005F02000029000800150006004C02CA000600EB00CA0006002900CD000600B102D00006009F03D00006009D00CD000600CD01D40006003E00CD000600EA02D00006009F03D00006009D00CD0006007A03D00006008700CD000600CD01D4005020000000008608C602580001006220000000008108D802D700010075200000000086085D00DD00020087200000000081087200E10002009A20000000008608AD00DD000300AC20000000008108C000E1000300BF200000000081000402E6000400E320000000008600F901EF00070006210000000081009602F70009002A210000000086008D0200010C004D21000000008618F2024D000E007821000000008600DD0108010F00342200000000860077020F0111001C230000000086009F02080115001024000000008600810208011700B824000000008600EB010801190060250000000081001E00DD001B0080250000000081003300DD001B00A0250000000081003E0219011B00F425000000008100B80224011F0000000100C70100000100C70100000100C70100000100A80300000200A500000003000F0200000100A80300000200A50000000100A80300000200A50000000300AB0200000100A80300000200A500000001001D0100000100A80300000200A50000000100A80300000200A500000003008A0300000400960000000100A80300000200A50000000100A80300000200A50000000100A80300000200A50000000100A80300000200A50000000300390200000400690200000100A80300000200A5000900F20201001100F20206001900F2020A002900F2020600310041011000590046031500590051031B0059000100220059000B002700690073032D005900C20334005900B80341003100F2024D003100DC00530079006C0258003900E30367003100DC036F0031001702750031001B02AD0049003A03B9004900B701BD002E000B0035012E0013003E012E001B005D014300230066015D0081008D0096009D00A400A800020001000000DC022C010000760031010000C40031010200010003000100020003000200030005000100040005000200050007000100060007000480000000000000000000000000000000009A030000040000000000000000000000C10046000000000002000000000000000000000000005C030000000003000200040002000500020017003C0019003C00170048001900480025007C0000000047657455496E7436340053657455496E743634003C4D6F64756C653E0047656E65726174654E65774C697374696E6749440047656E65726174654E65774F6666657249440053797374656D2E507269766174652E436F72654C6962006765745F43757272656E744C697374696E674964007365745F43757272656E744C697374696E674964004C697374696E67546F6B656E4964006C697374696E67546F6B656E496400746F6B656E4964006765745F43757272656E744F666665724964007365745F43757272656E744F66666572496400494D657373616765006765745F4D657373616765004C6F674D657373616765004E465445786368616E67650056616C7565547970650049536D617274436F6E7472616374537461746500736D617274436F6E74726163745374617465004950657273697374656E745374617465006765745F50657273697374656E7453746174650044656275676761626C6541747472696275746500436F6D70696C6174696F6E52656C61786174696F6E73417474726962757465004465706C6F794174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465006765745F52657475726E56616C75650076616C756500497341637469766500537472696E67004372656174654C697374696E670043616E63656C4C697374696E67004765744C697374696E67005365744C697374696E67006C697374696E67004C6F670043616C6C00536D617274436F6E74726163742E646C6C0053797374656D0066726F6D005472616E73666572546F6B656E00416374696F6E004C697374696E67496E666F004F66666572496E666F00746F006765745F53656E646572004D616B654F666665720043616E63656C4F66666572004765744F66666572005365744F66666572004163636570744F66666572006F666665720053656C6C657200476574546F6B656E4F776E6572006765745F436F6E74726163744F776E6572007365745F436F6E74726163744F776E6572004F666665726572002E63746F720053797374656D2E446961676E6F73746963730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300446562756767696E674D6F646573006765745F537563636573730047657441646472657373005365744164647265737300537472617469732E536D617274436F6E74726163747300466F726D6174004C697374696E67436F6E7472616374006C697374696E67436F6E747261637400536D617274436F6E747261637400636F6E7472616374004F626A656374004765745374727563740053657453747275637400495472616E73666572526573756C7400417373657274006F705F457175616C6974790000001B43006F006E00740072006100630074004F0077006E00650072000021430075007200720065006E0074004C0069007300740069006E00670049006400001D430075007200720065006E0074004F00660066006500720049006400001F4C0069007300740069006E0067003A007B0030007D003A007B0031007D00001B4F0066006600650072003A007B0030007D003A007B0031007D0000615400680065002000650078006300680061006E0067006500200063006F006E007400720061006300740020006900730020006E006F00740020006F0077006E006500720020006F0066002000740068006500200074006F006B0065006E002E000041540068006500200074006F006B0065006E00200069007300200061006C007200650061006400790020006F006E0020006C0069007300740069006E0067002E0000174100630063006500700074004F00660066006500720000395300750063006300650073007300660075006C006C0079002000630072006500610074006500640020006C0069007300740069006E00670000415400680065002000730065006C006C0069006E006700200074006F006B0065006E0020006900730020006E006F00740020006C00690073007400650064002E00004F54006800650020006F00660066006500720069006E006700200074006F006B0065006E00200069007300200061006C007200650061006400790020006F006E0020006F0066006600650072002E0000355300750063006300650073007300660075006C006C0079002000630072006500610074006500640020006F006600660065007200003754006800650020006F00660066006500720020006900730020006E006F007400200061007600610069006C00610062006C0065002E000053430061006C006C006500720020006900730020006E006F00740020007400680065002000730065006C006C006500720020006F0066002000740068006900730020006C0069007300740069006E0067002E0000375300750063006300650073007300660075006C006C00790020006100630063006500700074006500640020006F0066006600650072000051430061006C006C006500720020006900730020006E006F007400200074006800650020006F0066006600650072006500720020006F0066002000740068006900730020006F0066006600650072002E000017430061006E00630065006C004F00660066006500720000395300750063006300650073007300660075006C006C0079002000630061006E00630065006C006C006500640020006F006600660065007200003B54006800650020006C0069007300740069006E00670020006900730020006E006F007400200061007600610069006C00610062006C0065002E00001B430061006E00630065006C004C0069007300740069006E006700003D5300750063006300650073007300660075006C006C0079002000630061006E00630065006C006C006500640020006C0069007300740069006E00670000195400720061006E007300660065007200460072006F006D0000614600610069006C0065006400200074006F00200069006E0076006F006B00650020005400720061006E007300660065007200460072006F006D0020006F006E00200074006F006B0065006E00200063006F006E00740072006100630074002E00000F4F0077006E00650072004F00660000574600610069006C0065006400200074006F00200069006E0076006F006B00650020004F0077006E00650072004F00660020006F006E00200074006F006B0065006E00200063006F006E00740072006100630074002E00000000001DA21457CFE19B45A925DDA99226BD7B00042001010803200001052001011111042000122D052001111D0E062002010E111D0420010B0E052002010E0B0600030E0E1C1C07300102010E1E00040A011110063001011E000E040A011114052001011221042000123D042000111D0907040B11101110110C07000202111D111D05200201020E06300101011E00040A01110C0B07050B111011141114110C08070311141110110C0607021114110C0607021110110C0307010B04070112250B20051225111D0B0E1D1C0B032000020320001C087CEC85D7BEA7798E02060E02060B0306111D02060205200101111D0320000B042001010B08200301111D0B11100720021110111D0B08200301111D0B11140720021114111D0B06200201111D0B09200401111D0B111D0B0A200401111D0B111D111D072002111D111D0B042800111D0328000B0801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F777301080100020000000000040100000000000000000000000000000000100000000000000000000000000000001436000000000000000000002E36000000200000000000000000000000000000000000000000000020360000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF2500200010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000C000000403600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
```
#### Building the contracts

Prerequisite: Download the [Stratis SmartContracts Tools](https://github.com/stratisproject/Stratis.SmartContracts.Tools.Sct)

1. Clone the source code from repo
```
git clone <url>
```

2. Restore the NFT Token Sample Contract
```
> cd NFTStandardERC721
> dotnet restore
```

3. Build the NFT Token Sample Contract. Take note of the output byte code.
```
> cd ../Stratis.SmartContracts.Tools.Sct/Stratis.SmartContracts.Tools.Sct
> dotnet run validate ../../StratisNFTExchangeContracts/NFTStandardERC721/NFTStandardERC721.cs -sb
```

4. Restore the NFT Exchange Contract
```
> cd NFTExchange
> dotnet restore
```

5. Build the NFT Exchange Contract. Take note of the output byte code.
```
> cd ../Stratis.SmartContracts.Tools.Sct/Stratis.SmartContracts.Tools.Sct
> dotnet run validate ../../StratisNFTExchangeContracts/NFTExchange/NFTExchange.cs -sb
```

#### Running local chain

1. Pull Stratis node docker image
```
docker pull stratisplatform/stratisfullnode:Stratis.CirrusMinerD-1.1.0.0-ext
```

2. Run the stratis node docker image
```
docker run -p 38223:38223 stratisplatform/stratisfullnode:Stratis.CirrusMinerD-1.1.0.0-ext
```

3. Browse node API
http://localhost:38223/Swagger

#### Deploying the contracts

1. Find the wallet address on the local chain which has GAS.
```
curl --location -g --request GET 'http://localhost:38223/api/Wallet/list-wallets' \
--header 'Accept: application/json'

curl --location -g --request GET 'http://localhost:38223/api/Wallet/addresses?WalletName=cirrusdev' \
--header 'Accept: application/json'
```

2. Deploy the contract. Take note of the TxHash in the response. On loal node, the wallet password is `password`
```
curl --location -g --request POST 'http://localhost:38223/Swagger/api/SmartContractWallet/create' \
--header 'Content-Type: application/json-patch+json' \
--header 'Accept: application/json' \
--data-raw '{ 
    "walletName": "{{wallet-name}}", 
    "amount": "0", 
    "feeAmount": "0.001", 
    "password": "{{wallet-password}}", 
    "contractCode": "{{contract-bytecode}}", 
    "gasPrice": 100, 
    "gasLimit": 100000, 
    "sender": "{{wallet-address}}"
}'
```

2. Get the new contract address from the response
```
curl --location -g --request GET 'http://localhost:38223/api/SmartContracts/receipt?txHash={{TxHash}}' \
--header 'Accept: application/json'
```

## Interacting With the Contracts

A complete Postman collection is available for all the public functions in smart contracts.
- [Postman Collection](https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/Postman/StratisNFTExchange.postman_collection.json)
- [Postman Environment Config](https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/Postman/StratisNFTExchange.postman_environment.json)

##### NFT Exchange Contract Functions
| Function      | Description                                                                                                                                 |
|---------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| CreateListing | Creates a listing of an NFT token making it available for receiving offers.                                                                 |
| MakeOffer     | Makes an offer for an NFT listing, providing an NFT token as the offer item.                                                                |
| AcceptOffer   | Accept an open offer and performs the exchange transaction by transferring the offered NFT to the seller and the listed NFT to the offerer. |
| CancelOffer   | Cancel an open offer. Invoker must be the offerer of this offer.                                                                            |
| CancelListing | Cancel an open listing. Invoker must be the seller of this listing.                                                                         |


##### NFT Sample Contract Functions
*This is only a dummy NFT contract created for the purpose of testing and development.*

| Function           | Description                                    |
|--------------------|------------------------------------------------|
| Mint               | Mint a new NFT.                                |
| OwnerOf            | Gets the owner of the given token ID.          |
| TransferFrom       | Transfer a token to the given address.         |
| GetTokenProperties | Get the data properties of the given token ID. |

## Screenshots

// TODO: Landing Page
<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/images/1.png" alt="">
</p>

// TODO: Listings
<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/images/2.png" alt="">
</p>

// TODO: Create Listing
<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/images/3.png" alt="">
</p>

// TODO: View Listing
<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/images/4.png" alt="">
</p>

// TODO: Make an offer
<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/images/5.png" alt="">
</p>

// TODO: Accept Offer
<p align="center">
    <img src="https://raw.githubusercontent.com/jnlewis/StratisNFTExchangeContracts/main/docs/images/6.png" alt="">
</p>

## License

- Open source <a href="https://github.com/jnlewis/notai-web/blob/main/LICENSE">Apache-2.0 License</a>
