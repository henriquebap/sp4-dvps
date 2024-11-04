namespace cha3.Controllers
{
    public class ConfiguracaoSingleton
    {
        private static ConfiguracaoSingleton _instancia;
        private static readonly object _lock = new object();

        public string Configuracao { get; private set; }

        private ConfiguracaoSingleton()
        {
            Configuracao = "Valor Inicial";
        }
        public static ConfiguracaoSingleton Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new ConfiguracaoSingleton();
                    }
                    return _instancia;
                }
            }
        }

        public void AtualizarConfiguracao(string novaConfiguracao)
        {
            Configuracao = novaConfiguracao;
        }
    }
}
