namespace InfoTecsIntro.Config
{
    public interface IGetConfig<out T>
    {
        public T GetConfig();
    }
}