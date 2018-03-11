public class Pet : Citizen, IBirthDate
{
    public override string BirthDate { get => base.BirthDate; set => base.BirthDate = value; }

    public Pet(string name, string birthDate)
        :base(name)
    {
        this.BirthDate = birthDate;
    }
}
