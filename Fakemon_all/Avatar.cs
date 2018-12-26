namespace Fakemon
{
    class Avatar
    {
        int energia;
        int apetito;
        int diversion;

        
        public Avatar(int e, int a, int d)
        {
            energia = e;
            apetito = a;
            diversion = d;
        }

        public int Energia
        {
            get
            {
                return energia;
            }

            set
            {
                energia = value;
            }
        }

        public int Apetito
        {
            get
            {
                return apetito;
            }

            set
            {
                apetito = value;
            }
        }

        public int Diversion
        {
            get
            {
                return diversion;
            }

            set
            {
                diversion = value;
            }
        }

    }
}