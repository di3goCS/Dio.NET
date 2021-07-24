namespace banco
{
    public class Person
    {
        public string Name{get;set;}
        private string BirthDate{get;set;}

        public Person(string name, string birthdate){
            this.Name = name;
            this.BirthDate = birthdate;
        }

        public override string ToString(){
            string result = "";
            result += this.Name = " | ";
            return result;
        }
    }
}