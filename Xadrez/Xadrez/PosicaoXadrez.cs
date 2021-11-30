using Tabuleiro;

namespace Xadrez {
    class PosicaoXadrez {

        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }
    }
}
