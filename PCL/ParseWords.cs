// 
// Pyper - automate the transformation of text using "stackable" text filters
// Copyright (C) 2013  Barry Block 
// 
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version. 
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY
// WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
// PARTICULAR PURPOSE.  See the GNU General Public License for more details. 
// 
// You should have received a copy of the GNU General Public License along with
// this program.  If not, see <http://www.gnu.org/licenses/>. 
// 
using System;

namespace Firefly.Pyper
{
   /// <summary>
   ///    Parses the text into individual words.
   /// </summary>
   public sealed class ParseWords : FilterPlugin
   {
      public override void Execute()
      {
         string delims = CmdLine.GetStrSwitch("/D", " ");
         char[] delimsArr = delims.ToCharArray();

         Open();

         try
         {
            while (!EndOfText)
            {
               string line = ReadLine();
               string[] words = line.Split(delimsArr, StringSplitOptions.RemoveEmptyEntries);

               foreach (string word in words)
               {
                  WriteText(word);
               }
            }
         }

         finally
         {
            Close();
         }
      }

      public ParseWords(IFilter host) : base(host)
      {
         Template = "/Ds";
      }
   }
}