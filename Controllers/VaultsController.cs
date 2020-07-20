using keepr.Services;

namespace keepr.Controllers
{
    public class VaultsController
    {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    } 
    }
}