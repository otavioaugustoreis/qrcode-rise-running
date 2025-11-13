namespace RiseRunning_ScannerCode.Model.Commons
{
    public static class MessageCommons
    {
        public static string RunnerRegistrado(string nome) => $"Corredor {nome} registrado!";
        public static string RunnerJaRegistrado(string nome) => $"Corredor {nome} já está registrado!";
        public const string RunnerCpf = "CPF inválido!";
    }
}
