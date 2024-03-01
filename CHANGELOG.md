# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.0.0-pre.6] - 2024-02-29
### Added
* SdkWrapper class
### Changed
* SdkWrapper.GetWalletAssets now gets the tokens found in the txIn
* Changed Demo classes SDKClient and SDKServer to utilize SdkWrapper class

## [1.0.0-pre.5] - 2024-02-08
* API Changes and Demo Readme changes
### Known Issues
* API Endpoint GET '/v2/GetAllAssetsInWallet/{address}' returns error 500 response
### Added
* Dataproviders enum [Default, Koios, Blockfrost, Cli, Maestro]
### Changed
* SDK method Using GetAllAssetsInWallet instead of GetWalletUtxo because TxInAddressesClass does not return assets
* API Endpoint POST '/v2/MakeTransaction/{customerid}' Request: CreateManagedWalletTransactionClass
* Schema Model CreateManagedWalletTransactionClass
* Schema Model TxInAddressesClass


## [1.0.0-pre.4] - 2024-01-25
* Review before Asset Store submission.
### Added
* Added Demo Project to Samples.

## [1.0.0-pre.1] - 2023-11-01