using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
namespace ca.HenrySoftware
{
	public class Gename
	{
		private class Data
		{
			public List<string> Name = new List<string>();
			public List<string> Start = new List<string>();
			public List<string> Middle = new List<string>();
			public List<string> Finish = new List<string>();
			public List<string> Pre = new List<string>();
			public List<string> Post = new List<string>();
		}
		private Data _male = new Data();
		private Data _female = new Data();
		private char[] _vowel = { 'a', 'e', 'i', 'o', 'u', 'y' };
		private Random _random = new Random(Guid.NewGuid().GetHashCode());
		public Gename()
		{
			try
			{
				Setup();
			}
			catch (Exception e)
			{
				Debug.Print("!!!Error: " + e.Message);
			}
		}
		public void Setup()
		{
			var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			// m, f, n
			using (var name = new StreamReader(Path.Combine(dir, @"Name.csv")))
			{
				while (!name.EndOfStream)
				{
					var line = name.ReadLine();
					var values = line.Split(',');
					var male = values.Length >= 1 ? values[0] : null;
					if (!string.IsNullOrEmpty(male))
						_male.Name.Add(male);
					var female = values.Length >= 2 ? values[1] : null;
					if (!string.IsNullOrEmpty(female))
						_female.Name.Add(female);
					var neutral = values.Length >= 3 ? values[2] : null;
					if (!string.IsNullOrEmpty(neutral))
					{
						_male.Name.Add(neutral);
						_female.Name.Add(neutral);
					}
				}
			}
			// ms, mm, mf, fs, fm, ff, ns, nm, nf
			using (var syllable = new StreamReader(Path.Combine(dir, @"Syllable.csv")))
			{
				while (!syllable.EndOfStream)
				{
					var line = syllable.ReadLine();
					var values = line.Split(',');
					var maleStart = values.Length >= 1 ? values[0] : null;
					if (!string.IsNullOrEmpty(maleStart))
						_male.Start.Add(maleStart);
					var maleMiddle = values.Length >= 2 ? values[1] : null;
					if (!string.IsNullOrEmpty(maleMiddle))
						_male.Middle.Add(maleMiddle);
					var maleFinish = values.Length >= 3 ? values[2] : null;
					if (!string.IsNullOrEmpty(maleFinish))
						_male.Finish.Add(maleFinish);
					var femaleStart = values.Length >= 4 ? values[3] : null;
					if (!string.IsNullOrEmpty(femaleStart))
						_female.Start.Add(femaleStart);
					var femaleMiddle = values.Length >= 5 ? values[4] : null;
					if (!string.IsNullOrEmpty(femaleMiddle))
						_female.Middle.Add(femaleMiddle);
					var femaleFinish = values.Length >= 6 ? values[5] : null;
					if (!string.IsNullOrEmpty(femaleFinish))
						_female.Finish.Add(femaleFinish);
					var neutralStart = values.Length >= 7 ? values[6] : null;
					if (!string.IsNullOrEmpty(neutralStart))
					{
						_male.Start.Add(neutralStart);
						_female.Start.Add(neutralStart);
					}
					var neutralMiddle = values.Length >= 8 ? values[7] : null;
					if (!string.IsNullOrEmpty(neutralMiddle))
					{
						_male.Middle.Add(neutralMiddle);
						_female.Middle.Add(neutralMiddle);
					}
					var neutralFinish = values.Length >= 9 ? values[8] : null;
					if (!string.IsNullOrEmpty(neutralFinish))
					{
						_male.Finish.Add(neutralFinish);
						_female.Finish.Add(neutralFinish);
					}
				}
			}
			// mp, mp, fp, fp, np, np
			using (var title = new StreamReader(Path.Combine(dir, @"Title.csv")))
			{
				while (!title.EndOfStream)
				{
					var line = title.ReadLine();
					var values = line.Split(',');
					var malePre = values.Length >= 1 ? values[0] : null;
					if (!string.IsNullOrEmpty(malePre))
						_male.Pre.Add(malePre);
					var malePost = values.Length >= 2 ? values[0] : null;
					if (!string.IsNullOrEmpty(malePost))
						_male.Post.Add(malePost);
					var femalePre = values.Length >= 3 ? values[2] : null;
					if (!string.IsNullOrEmpty(femalePre))
						_female.Pre.Add(femalePre);
					var femalePost = values.Length >= 4 ? values[3] : null;
					if (!string.IsNullOrEmpty(femalePost))
						_female.Post.Add(femalePost);
					var neutralPre = values.Length >= 5 ? values[4] : null;
					if (!string.IsNullOrEmpty(neutralPre))
					{
						_male.Pre.Add(neutralPre);
						_female.Pre.Add(neutralPre);
					}
					var neutralPost = values.Length >= 6 ? values[5] : null;
					if (!string.IsNullOrEmpty(neutralPost))
					{
						_male.Post.Add(neutralPost);
						_female.Post.Add(neutralPost);
					}
				}
			}
		}
		public string Name(
			double sex = .5,
			double generated = .5,
			double pre = .333,
			double vowel = .8,
			double middle0 = .3,
			double middle1 = .1,
			double post = .22)
		{
			var name = string.Empty;
			var male = sex > _random.NextDouble();
			if (pre > _random.NextDouble())
			{
				name += male ? _male.Pre[_random.Next(_male.Pre.Count)] : _female.Pre[_random.Next(_female.Pre.Count)];
				name += " ";
				post += .5;
			}
			if (generated > _random.NextDouble())
			{
				name += male ? _male.Start[_random.Next(_male.Start.Count)] : _female.Start[_random.Next(_female.Start.Count)];
				if (vowel > _random.NextDouble())
				{
					name += _vowel[_random.Next(_vowel.Length)];
				}
				if (middle0 > _random.NextDouble())
				{
					name += male ? _male.Middle[_random.Next(_male.Middle.Count)] : _female.Middle[_random.Next(_female.Middle.Count)];
				}
				if (middle1 > _random.NextDouble())
				{
					name += male ? _male.Middle[_random.Next(_male.Middle.Count)] : _female.Middle[_random.Next(_female.Middle.Count)];
				}
				name += male ? _male.Finish[_random.Next(_male.Finish.Count)] : _female.Finish[_random.Next(_female.Finish.Count)];
			}
			else
				name += male ? _male.Name[_random.Next(_male.Name.Count)] : _female.Name[_random.Next(_female.Name.Count)];
			if (post > _random.NextDouble())
			{
				name += " ";
				name += male ? _male.Post[_random.Next(_male.Post.Count)] : _female.Post[_random.Next(_female.Post.Count)];
			}
			return name;
		}
	}
}
