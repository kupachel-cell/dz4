using System;


namespace dz1lat{
    struct Grandpa
    {
        public string Name;
        public GrumpinessLevel Grumpiness;
        public string[] GrumblePhrases;
        public int BruisesCount;
        public Grandpa(string name, GrumpinessLevel grumpiness, string[] phrases)
        {
            Name = name;
            Grumpiness = grumpiness;
            GrumblePhrases = phrases;
            BruisesCount = 0;
        }
        public int CheckSwearWords(Grandpa targetGrandpa, params string[] badWords)
        {
            int newBruises = 0;
            foreach (string phrase in targetGrandpa.GrumblePhrases)
            {
                foreach (string badWord in badWords)
                {
                    if (phrase.ToLower().Contains(badWord.ToLower()))
                    {
                        newBruises++;
                    }
                }
            }

            return newBruises;
        }
    }
    internal class structure2
    {
    }
}
