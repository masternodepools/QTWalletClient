# QTWalletClient
Simple client to communicate with qt-wallets.

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
      IpAddress = "http://localhost:9050",
      UserName = "Administrator",
      Password = "SuperSecretPassword1336"
  });

  // Get a new wallet address with alias "someAlias"
  var response = client.SendCommand(WalletCommands.GetNewAddress, "someAlias");
  var newAddress = response.Result;
  Console.WriteLine(newAddress);
```
