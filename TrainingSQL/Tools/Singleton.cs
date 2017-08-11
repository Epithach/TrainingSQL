namespace TrainingSQL.Tools
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        Singleton()
        {

        }
        
        public static Singleton GetInstance()
        {
            lock ((padlock))
            {
                // Si pas d'instance existante on en crée une...
                if (instance == null)
                {
                    instance = new Singleton();
                }

                // On retourne l'instance de MonSingleton
                return instance;
            }

        }

    }
}