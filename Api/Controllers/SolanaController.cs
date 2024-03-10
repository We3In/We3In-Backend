
using Microsoft.AspNetCore.Mvc;
using Solnet.KeyStore;
using Solnet.KeyStore.Model;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolanaController : ControllerBase
    {
        private readonly IRpcClient _rpcClient;

        public SolanaController()
        {
            _rpcClient = ClientFactory.GetClient(Cluster.TestNet);
        }

        [HttpGet("[action]")]
        public IActionResult CreateWallet(string password)
        {
            var secretKeyStoreService = new SecretKeyStoreService();

            Wallet wallet = new Wallet(WordCount.TwentyFour, WordList.English);
            var publicKey = wallet.GetAccount(0).PublicKey;
            var privateKey = wallet.GetAccount(0).PrivateKey;
            byte[] bytes = wallet.GetAccount(0).PrivateKey.KeyBytes;

            // Encrypt a private key, seed or mnemonic associated with a certain address
            var jsonString = secretKeyStoreService.EncryptAndGenerateDefaultKeyStoreAsJson(password, bytes, publicKey);

            
            return Ok(jsonString);
            
        }


        [HttpGet("[action]")]
        public IActionResult checkBalance(string publicKey)
        {
            var balance = _rpcClient.GetBalance(publicKey);

            return Ok(balance.Result.Value);
        }

        [HttpGet("[action]")]   
        public async Task<IActionResult> TransferAsync()
        {
            var tx = new TransactionBuilder();

            tx.AddInstruction(
                new TransactionInstruction() {
                    Keys = null,
                    ProgramId = new PublicKey("7cBTgEf3vCgNqqp63wNAPFhXK2MDAsRz7co4kCtXJuNp")
                });
                
            var tx_hash = _rpcClient.SendTransaction(tx.ToString());

            return Ok(true);

        }

    }
}
