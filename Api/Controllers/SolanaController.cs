using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solnet.Rpc;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolanaController : ControllerBase
    {
        IRpcClient rpcClient;

        public SolanaController()
        {
            this.rpcClient = ClientFactory.GetClient(Cluster.TestNet);
        }

        [HttpGet("[action]")]
        public IActionResult CreateWallet()
        {
            Wallet wallet = new Wallet(WordCount.TwentyFour, WordList.English);

            return Ok(wallet);
        }

        [HttpGet("[action]")]
        public IActionResult checkBalance(string publicKey)
        {
            var balance = rpcClient.GetBalance(publicKey);

            return Ok(balance.Result.Value);
        }

    }
}
