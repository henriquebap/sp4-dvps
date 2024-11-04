using System.ComponentModel;

namespace cha3.Enums
{
    public enum Status
    {
        [Description("Não Pagou pelo produto.")]
        NaoPagou = 1,
        [Description("Pagou pelo produto.")]
        Pagou = 2
    }
}
