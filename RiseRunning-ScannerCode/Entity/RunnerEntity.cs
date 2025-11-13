namespace RiseRunning_ScannerCode.Entity
{
    public record RunnerDTO(string Nome, long Cpf, DateTime DataHora);

    public class RunnerEntity
    {
        public Guid Id { get; set; } = new Guid();

        public string Nome { get; set; } = string.Empty;

        public long Cpf { get; set; }

        public DateTime DataHora { get; set; } = DateTime.UtcNow;
    }
}
