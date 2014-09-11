namespace _03.BiDictionaryImplementation
{
    using System;
    /*
     *Implement a class BiDictionary<K1,K2,T> 
     *that allows adding triples {key1, key2, value} 
     *and fast search by key1, key2 or by both key1 and key2.      *Note: multiple values can be stored for given key.
     */
    public class TestBiDictionary
    {
        public static void Main(string[] args)
        {
            var personNamesAndAges = new BiDictionary<string, string, int>();
            personNamesAndAges.Add("Mariq", "Ivanova", 25);
            personNamesAndAges.Add("Mariq", "Georgieva", 24);
            personNamesAndAges.Add("Ivancho", "Kalpazancho", 13);
            var agesOfAllMarias = personNamesAndAges.FindByFirstKey("Mariq");
            Console.WriteLine("Ages of girls with first name Mariq: {0}", string.Join(", ", agesOfAllMarias));
            var agesOfAllMariaIvanova = personNamesAndAges.FindByBothKeys("Mariq", "Ivanova");
            Console.WriteLine("Ages of girls named Mariq Ivanova: {0}", string.Join(", ", agesOfAllMariaIvanova));
            var agesOfAllKalpazanchos = personNamesAndAges.FindBySecondKey("Kalpazancho");
            Console.WriteLine("Ages of boys with last name Kalpazancho: {0}", string.Join(", ", agesOfAllKalpazanchos));
        }
    }
}
