namespace Haze.Core.Domain.Common
{
    public static class CoreUserMessages
    {
        public static UserMessage RegistroExistente => new UserMessage("Registro já existente.");
        public static UserMessage RegistroNaoEncontrado => new UserMessage("Registro não encontrado.");
        public static UserMessage ValorDuplicadoO => new UserMessage("O {0} informado já foi cadastrado em outro registro.");
        public static UserMessage ValorDuplicadoA => new UserMessage("A {0} informada já foi cadastrada em outro registro.");
        public static UserMessage ValorObrigatorioO => new UserMessage("Por favor informe o {0}.");
        public static UserMessage ValorObrigatorioA => new UserMessage("Por favor informe a {0}");
        public static UserMessage ErroPersistenciaDados => new UserMessage("Erro ao persistir no banco.");
        public static UserMessage ValorNaoEncontradoO => new UserMessage("O {0} informado não foi encontrado.");
        public static UserMessage ValorNaoEncontradoA => new UserMessage("A {0} informada não foi encontrada.");
    }
}