# Makefile
# provides helper targets to run docker-compose commands

# all targets are phony
# https://www.gnu.org/software/make/manual/html_node/Phony-Targets.html
.PHONY: pull-node run-node browse prepare-contract build-contract

pull-node:
    docker pull stratisplatform/stratisfullnode\:Stratis.CirrusMinerD-1.1.0.0-ext

run-node:
    docker run -p 38223\:38223 stratisplatform/stratisfullnode\:Stratis.CirrusMinerD-1.1.0.0-ext

browse-node:
	open http\://localhost\:38223/Swagger

prepare-contract-nft:
	cd NFTStandardERC721
	dotnet restore

prepare-contract-exchange:
	cd NFTExchange
	dotnet restore

build-contract-nft:
    cd ../Stratis.SmartContracts.Tools.Sct/Stratis.SmartContracts.Tools.Sct
    dotnet run validate ../../StratisNFTExchangeContracts/NFTStandardERC721/NFTStandardERC721.cs -sb

build-contract-exchange:
    cd ../Stratis.SmartContracts.Tools.Sct/Stratis.SmartContracts.Tools.Sct
    dotnet run validate ../../StratisNFTExchangeContracts/NFTExchange/NFTExchange.cs -sb
