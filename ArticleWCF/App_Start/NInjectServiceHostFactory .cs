using ArticleWCF.Implementation;
using ArticleWCF.Mapper;
using ArticleWCF.Repository;
using ArticleWCF.Service;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;

namespace ArticleWCF.App_Start
{
    public class NInjectServiceHostFactory : ServiceHostFactory
    {
        private readonly IKernel kernel;

        public NInjectServiceHostFactory()
        {
            kernel = new StandardKernel();
            //add the rest of the mappings here
            kernel.Bind<ArticleContext>().ToSelf();
            kernel.Bind<Mapper.Mapper>().ToSelf();
            kernel.Bind<IArticleService>().To<ArticleServiceImplementation>();
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new NInjectServiceHost(kernel, serviceType, baseAddresses);
        }
    }

    public class NInjectServiceHost : ServiceHost
    {
        public NInjectServiceHost(IKernel kernel, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (kernel == null) throw new ArgumentNullException("kernel");
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new NInjectInstanceProvider(kernel));
            }
        }
    }
}