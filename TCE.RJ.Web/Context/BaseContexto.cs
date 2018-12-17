using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TCE.RJ.Web.Context
{
    public class BaseContexto : DbContext
    {
        public BaseContexto()
            : base("TCERJDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public class TceInitializer : DropCreateDatabaseIfModelChanges<BaseContexto>
        {
            public TceInitializer()
            {
                // PARA NÃO FAZER NADA, COMENTA TUDO

                // RECRIA QQ ALTERACAO
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TCERJContexto>());

                // CRIA SOMENTE SE NAO TIVER NADA
                //Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<TCERJContexto>());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            Database.SetInitializer(new TceInitializer());
        }

    }
}