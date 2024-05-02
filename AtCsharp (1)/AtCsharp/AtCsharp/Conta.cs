namespace atCsharp
{
    internal class Conta : IInterface
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Saldo { get; set; }

        public Conta() { }

        public Conta(int id, string name, double saldo)
        {
            ID = id;
            Name = name;
            Saldo = saldo;
        }

        override
         public string ToString()
        {
            return "\n Id da conta: " + ID + "\n Nome da conta: " + Name + "\n Saldo da conta: " + Saldo + "\n";
        }

        public double Creditar(double valor)
        {
            return Saldo += valor;
        }

        public double Debitar(double valor)
        {
            return Saldo -= valor;
        }



    }
}
