# QTWalletClient in C# .Net
Simple client to communicate with qt-wallets, such as bitcoin-qt.

Example usage:

Set up QT wallet configfile:
```conf
rpcuser=Administrator
rpcpassword=SuperSecretPassword1336
rpcport=9050   
```

Communicate with wallet:
```C#
var client = new WalletClient(new WalletSettings {
    Ip = "127.0.0.1",
    Port = 9050,
    UserName = "Administrator",
    Password = "SuperSecretPassword1336"
});

// Get balance
var balanceResponse = await client.SendCommandAsync("getbalance");
var balance = blockCountResponse.Result;
Console.WriteLine(balance);

// Get block count
var blockCountResponse = await client.SendCommandAsync(WalletCommands.GetBlockCount);
var blockCount = blockCountResponse.Result;
Console.WriteLine(blockCount);

// Get a new wallet address with alias "someAlias"
var addressResponse = await client.SendCommandAsync(WalletCommands.GetNewAddress, "someAlias");
var newAddress = addressResponse.Result;
Console.WriteLine(newAddress);
```

TODO:
Add wallet commands.
