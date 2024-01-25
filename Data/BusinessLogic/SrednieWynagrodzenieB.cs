namespace FirmaMeble.Data.BusinessLogic
{
    using System;
    using DbContexts;

    public static class SrednieWynagrodzenieB
    {
        
        public static decimal? SrednieWynagrodzenie(DateTime data, int IdStanowiska)
        {
            try
            {
                var dbContext = new DataBaseEntities();
                if (IdStanowiska != null)
                {
                    return
                        (
                            from umowa in dbContext.UmowaDbSet
                            where
                            umowa.StanowiskoId == IdStanowiska &&
                            umowa.CzyAktywna == true &&
                            umowa.DataRozpoczecia <= data &&
                            umowa.DataZakonczenia >= data
                            select
                            umowa.KwotaBrutto
                        ).Average();
                }
                else
                {
                    return
                    (
                        from umowa in dbContext.UmowaDbSet
                        where
                        umowa.CzyAktywna == true &&
                        umowa.DataRozpoczecia <= data &&
                        umowa.DataZakonczenia >= data
                        select
                        umowa.KwotaBrutto
                    ).Average();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
