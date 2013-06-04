namespace AbcPos.BackOffice.Win.Models.Entities
{
    public class JedinicaMere : Entity
    {
        private string m_Oznaka;
        public string Oznaka
        {
            get { return m_Oznaka; }
            set
            {
                if (value == m_Oznaka)
                {
                    return;
                }
                m_Oznaka = value;
                OnPropertyChanged("Oznaka");
            }
        }
    }
}