using System;
using System.Security.Cryptography.X509Certificates;

namespace Patterns.RandomCode
{
    public class CertFinder
    {
        public static void Run()
        {
            CertFinder certFinder = new CertFinder();
            certFinder.FindCertByThumbprint();
        }

        public void FindCertByThumbprint()
        {
            string certThumbPrint = "c01a0f11aa7de2a0358f6429021b3a6710ce28ca";
            X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            // Try to open the store.

            certStore.Open(OpenFlags.ReadOnly);
            // Find the certificate that matches the thumbprint.
            X509Certificate2Collection certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, certThumbPrint, false);
            certStore.Close();

            // Check to see if our certificate was added to the collection. If no, throw an error, if yes, create a certificate using it.
            if (0 == certCollection.Count)
            {
                Console.WriteLine("Error: No certificate found containing thumbprint ");
                return;
            }

            Console.WriteLine("Certificate was found");
        }
    }

}

