using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class ArgumentManipulator
    {
        private string Functionality { get; }
        private string Filename { get; }

        private bool WrongNumberOfArguments { get; } = false;

        public ArgumentManipulator(string[] args)
        {
            if (args.Length == 2)
            {
                Functionality = args[0];
                Filename = args[1];
            }
            else
            {
                WrongNumberOfArguments = true;
            }
        }

        private readonly string[] _versionArgs = { "-v", "--v", "/v", "--version" };
        private readonly string[] _sizeArgs = { "-s", "--s", "/s", "--size" };
        private readonly FileDetails _fileDetails = new FileDetails();

        public string Execute()
        {
            if (WrongNumberOfArguments) return "";
            if (_versionArgs.Contains(Functionality))
            {
                return _fileDetails.Version(Filename);
            }
            if (_sizeArgs.Contains(Functionality))
            {
                return _fileDetails.Size(Filename).ToString();
            }
            return "";
        }

    }
}
