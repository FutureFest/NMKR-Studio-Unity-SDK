## API Wrapper

- [x]  **Project Setup**
    - [x]  Create Github repository
    - [x]  Create Unity project
    - [x]  Design Unity package structure
- [x]  **API Endpoint Generation (shallow)**
    - [x]  Create Google Sheet of API endpoint wrapper creation status
        - [x]  https://docs.google.com/spreadsheets/d/1enQR4-Xoa4QNLdkPwohNyi_QgXsdKdzbdwmeTVlzh6Q/edit?usp=sharing
    - [x]  Create shallow SDK API endpoint wrappers for the following API categories
        - [x]  Customer
        - [x]  NFT
        - [x]  Address Reservation (Sale)
        - [x]  Tools
        - [x]  Wallet Validation
        - [x]  Projects
        - [x]  Payment Transactions
        - [x]  Managed Wallets
        - [x]  Auctions
        - [x]  Smart Contracts
        - [x]  Whitelists
        - [x]  Mint
        - [x]  IPFS
- [ ]  **SDK methods to facilitate an in-game minting experience (deep)**

## Design

### General UI/UX

- [x]  Design Account Creation / Sign in
- [x]  Design Storefront
- [x]  Design Inventory
- [x]  Design Error States and Buttons
- [x]  Design Managed Wallet address (Copy)

## Demo

### **User Authentication**

- [ ]  **Implement user registration functionality.**
    - [x]  Design a registration form
    - [ ]  Create registration form with fields for username and password.
    - [ ]  Implement Managed Wallets as accounts

### **Inventory Management**

- [ ]  **Display the user's purchased NFTs in their inventory.**
    - [x]  Design the UI for Inventory
    - [ ]  Create the UI for Inventory
    - [ ]  Retrieve the user's purchased NFTs from the managed wallet.
    - [ ]  Display the NFTs in the user's inventory.
- [ ]  **Send out NFT to external wallet**
    - [ ]  Implement the ability for users to input a wallet address to send out their NFTs
    - [ ]  Charge a small fee to send out NFT
    - [ ]  Create Error States
        - [ ]  Not enough ADA to send out NFT from inventory

### **NFT Purchase**

- [ ]  **Create a storefront for NFTs.**
    - [x]  Design a user-friendly NFT storefront interface.
    - [ ]  Develop a user-friendly NFT storefront interface.
    - [ ]  Populate the storefront with NFT listings.
- [ ]  **Allow users to select and purchase an NFT.**
    - [ ]  Implement the checkout process for sending to external address
    - [ ]  Implement the checkout process for sending to managed wallet
    - [ ]  Create Error States
        - [ ]  Not enough ADA to mint NFT to managed wallet

### Managed **Wallet Integration**

- [ ]  **Integrate NMKR SDK for managed wallet creation.**
    - [ ]  Generate unique wallet addresses for each user.
- [ ]  **Fund Wallet**
    - [ ]  Display wallet address (Top right corner)
    - [ ]  Copy address functionality
    - [ ]  Test wallet functionality, including deposits and withdrawals.

### General Tasks

- [ ]  Ensure error handling and validation throughout the application.
- [ ]  Test the entire application for functionality and performance.
- [ ]  Document the SDK and provide usage guidelines.