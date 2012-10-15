#!/usr/bin/env booi
"""
Generates test fixture from files under testcases/
"""
import System
import System.IO

def GetTestCaseName(fname as string):
	return Path.GetFileNameWithoutExtension(fname).Replace("-", "_")
	
def WriteTestCases(writer as TextWriter, baseDir as string):
	count = 0
	for fname in Directory.GetFiles(baseDir):
		continue unless fname.EndsWith(".js")
		++count
		writer.Write("""
	[Test]
	def ${GetTestCaseName(fname)}():
		RunTestCase("${fname.Replace('\\', '/')}")
		""")
	print "${count} test cases found in ${baseDir}."

def GenerateTestFixture(srcDir as string, targetFile as string, header as string):
	contents = GenerateTestFixtureSource(srcDir, header)
	if ShouldReplaceContent(targetFile, contents):
		WriteAllText(targetFile, contents)
		
def ShouldReplaceContent(fname as string, contents as string):
	if not File.Exists(fname): return true
	return ns(ReadAllText(fname)) != ns(contents)
	
def ReadAllText(fname as string):
	using reader=File.OpenText(fname):
		return reader.ReadToEnd()
		
def WriteAllText(fname as string, contents as string):
	using writer=StreamWriter(fname):
		writer.Write(contents)

def ns(s as string):
	return s.Trim().Replace("\r\n", Environment.NewLine)
	
def GenerateTestFixtureSource(srcDir as string, header as string):
	writer=StringWriter()
	writer.Write(header)	
	WriteTestCases(writer, srcDir)
	return writer.ToString()
	
GenerateTestFixture("testcases", "tests/IntegrationTest.Generated.boo", """
namespace UnityJSToBooCS.Tests

import NUnit.Framework
	
[TestFixture]
partial class IntegrationTest:
""")



