namespace WEXOCodeChallenge.Models
{
    public class Genre
    {
        private string name;
        private int id;

        public Genre(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
