class Program
{
	static void Main(string[] args)
	{
		string[] friends = new string[7]
		{
			"Ana",
			"Mario",
			"Oscar",
			"Omar",
			"Mia",
			"Fernando",
			null
		};

		friends[6] = "Esteban";
		//Console.WriteLine(friends[6]);

		int index = 0;

		while (index < friends.Length)
		{
            Console.WriteLine(friends[index]);
			index++;
        }

		bool run = true;

		for(int i = 0; i < friends.Length && run; i++)
		{
            Console.WriteLine(friends[i]);
        }
    }
}