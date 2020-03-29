using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class Program_ISP
    {
        public class Documnet
        {

        }

        public interface IMachine
        {
            void Print(Documnet d);
            void Scan(Documnet d);
            void Fax(Documnet d);

        }

        public interface IPrinter
        {
            void Print(Documnet d);
        }

        public interface IScan
        {
            void Scan(Documnet d);
        }

        public interface IFax
        {
            void Fax(Documnet d);
        }


        public interface IMultiFunctionInterface: IPrinter, IScan
        {

        }

        public class MFunctionPrint : IMultiFunctionInterface
        {
            private IPrinter printer;
            private IScan scanner;

            public MFunctionPrint(IPrinter printer, IScan scanner)
            {
                if (printer == null)
                {
                    throw new ArgumentNullException(paramName: nameof(printer));
                }
                if (scanner == null)
                {
                    throw new ArgumentNullException(paramName: nameof(scanner));
                }
                this.printer = printer;
                this.scanner = scanner;
            }

            public void Print(Documnet d)
            {
                printer.Print(d);
            }

            public void Scan(Documnet d)
            {
                scanner.Scan(d);
                // Decorator pattern
            }
        }
        public class MulitFunctionPrint : IPrinter, IScan, IFax
        {
            public void Fax(Documnet d)
            {
                //
            }

            public void Print(Documnet d)
            {
                //
            }

            public void Scan(Documnet d)
            {
                //
            }
        }

        public class OldFashinPrinter : IPrinter
        {
          
            public void Print(Documnet d)
            {
                throw new NotImplementedException();
            }

        }

        //public static void Main(string[] args)
        //{
            
        //}
    }
}
