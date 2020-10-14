namespace PesquisaEOrdenacao.Model
{
    public class Celula
    {
        private int _element;
        private Celula next;
        private Celula _previous;


        public int Element { get => _element; set => _element = value; }
        public Celula Next { get => next; set => next = value; }
        public Celula Previous { get => _previous; set => _previous = value; }

        public Celula(int element)
        {
            _element = element;
        }

        public Celula(int element, Celula next)
        {
            Element = element;
            Next = next;
        }

    }
}
