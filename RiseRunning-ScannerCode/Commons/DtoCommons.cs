using RiseRunning_ScannerCode.Entity;

namespace RiseRunning_ScannerCode.Commons
{
    public static class DtoCommons
    {
        public static RunnerDTO toDTO(this RunnerEntity entity)
        {
            return new RunnerDTO(entity.Nome, entity.Cpf, entity.DataHora);
        }
    }
}
