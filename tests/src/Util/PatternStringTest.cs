/*
 *
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 *
*/

using System;
using log4net.Util;
using NUnit.Framework;

namespace log4net.Tests.Util
{
    [TestFixture]
    public class PatternStringTest
    {
#if NETCORE
        [Test, Ignore("Environment.SpecialFolder is unavailable on NETCORE")]
#else
        [Test]
#endif
        public void TestEnvironmentFolderPathPatternConverter()
        {
            string[] specialFolderNames = Enum.GetNames(typeof(Environment.SpecialFolder));

            foreach (string specialFolderName in specialFolderNames)
            {
                string pattern = "%envFolderPath{" + specialFolderName + "}";

                PatternString patternString = new PatternString(pattern);

                string evaluatedPattern = patternString.Format();

                Environment.SpecialFolder specialFolder = 
                    (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), specialFolderName);

                Assert.AreEqual(Environment.GetFolderPath(specialFolder), evaluatedPattern);
            }
        }
    }
}
