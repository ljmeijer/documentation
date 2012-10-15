using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.IO;
using Boo.Lang.Compiler.MetaProgramming;
using Boo.Lang.Runtime;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace UnityExampleConverter.Tests
{
    [TestFixture]
    [Serializable]
    public class IntegrationTest
    {
        public void RunTestCase(string testFile)
        {
            try
            {
                string testFilePath = this.ResolvePath(testFile);
                CompileUnit[] array = CSharpAssertModule.Convert(new FileInput(testFilePath));
                CompileUnit resultingCSharpNode = array[0];
                CompileUnit resultingBooNode = array[1];
                string[] expectedOutput = this.GetExpectedOutput(testFilePath);
                string expectedCSharpOutput = expectedOutput[0];
                string expectedBooOutput = expectedOutput[1];
                string inputJSCode = expectedOutput[2];
                Debug.WriteLine("JavaScript:\n" + inputJSCode);

                var output = new StringWriter();
                resultingCSharpNode.Accept(new CSharpPrinter(output));
                Debug.WriteLine("Generated C#:\n" + output.ToString().TrimEnd());
                Debug.WriteLine("Generated Boo:\n" + resultingBooNode.ToCodeString());

                CSharpAssertModule.AssertCSharpCode(expectedCSharpOutput, resultingCSharpNode);
                StringsModule.AssertAreEqualIgnoringNewLineDifferences(expectedBooOutput, resultingBooNode.ToCodeString());
            }
            catch (CompilationErrorsException x)
            {
                Assert.Fail(x.Errors.ToString(true));
            }
        }
        public string ResolvePath(string fileName)
        {
            return Path.Combine(Paths.TestCases, fileName);
        }
        public string[] GetExpectedOutput(string fname)
        {
            if (fname == null)
            {
                throw new ArgumentNullException("fname");
            }
            string contents = File.ReadAllText(fname);
            string expectedCSharpOutput = this.ExtractCommentSection(contents, 0);
            if (expectedCSharpOutput == null)
            {
                throw new AssertionFailedException(new StringBuilder("Expecting comment section with c# code at ").Append(fname).ToString());
            }
            string expectedBooOutput = this.ExtractCommentSection(contents, expectedCSharpOutput.Length);
            if (expectedBooOutput == null)
            {
                throw new AssertionFailedException(new StringBuilder("Expecting comment section with boo code at ").Append(fname).ToString());
            }
            string inputJSCode = contents.Substring(contents.LastIndexOf("*/") + 2);
            return new string[]
			{
				expectedCSharpOutput,
				expectedBooOutput,
                inputJSCode
			};
        }
        public string ExtractCommentSection(string code, int startingIndex)
        {
            int start = code.IndexOf("/*", startingIndex);
            checked
            {
                string arg_45_0;
                if (start < 0)
                {
                    arg_45_0 = null;
                }
                else
                {
                    int end = code.IndexOf("*/", start + 2);
                    arg_45_0 = ((end >= 0) ? RuntimeServices.Mid(code, start + 2, end).Trim() : null);
                }
                return arg_45_0;
            }
        }
		
        [Test]
        public void AddComponentCall()
        {
            this.RunTestCase("testcases/AddComponentCall.js");
        }
        [Test]
        public void AnimationAttributes()
        {
            this.RunTestCase("testcases/AnimationAttributes.js");
        }
        [Test]
        public void AnimationClipInitialization()
        {
            this.RunTestCase("testcases/AnimationClipInitialization.js");
        }
        [Test]
        public void AnimationCurveInitialization()
        {
            this.RunTestCase("testcases/AnimationCurveInitialization.js");
        }
        [Test]
        public void AnotherOnMemberExpressionQuote()
        {
            this.RunTestCase("testcases/AnotherOnMemberExpressionQuote.js");
        }
        [Test]
        public void ArrayManualFill()
        {
            this.RunTestCase("testcases/ArrayManualFill.js");
        }
        [Test]
        public void BooleanDeclarationAndInitialization()
        {
            this.RunTestCase("testcases/BooleanDeclarationAndInitialization.js");
        }
        [Test]
        public void CarrierReturnScape()
        {
            this.RunTestCase("testcases/CarrierReturnScape.js");
        }
        [Test]
        public void ColorInitialization()
        {
            this.RunTestCase("testcases/ColorInitialization.js");
        }
        [Test]
        public void ComponentCall()
        {
            this.RunTestCase("testcases/ComponentCall.js");
        }
        [Test]
        public void ComponentInChildrenCall()
        {
            this.RunTestCase("testcases/ComponentInChildrenCall.js");
        }
        [Test]
        public void ComponentsCall()
        {
            this.RunTestCase("testcases/ComponentsCall.js");
        }
        [Test]
        public void ComponentsInChildrenCall()
        {
            this.RunTestCase("testcases/ComponentsInChildrenCall.js");
        }
        [Test]
        public void Coroutine()
        {
            this.RunTestCase("testcases/Coroutine.js");
        }
        [Test]
        public void CubemapInitialization()
        {
            this.RunTestCase("testcases/CubemapInitialization.js");
        }
        [Test]
        public void EscapeCharacters()
        {
            this.RunTestCase("testcases/EscapeCharacters.js");
        }
        [Test]
        public void ExplicitAwakeFunction()
        {
            this.RunTestCase("testcases/ExplicitAwakeFunction.js");
        }
        [Test]
        public void FindObjectsOfTypeCall()
        {
            this.RunTestCase("testcases/FindObjectsOfTypeCall.js");
        }
        [Test]
        public void FloatDeclarationAndInitialization()
        {
            this.RunTestCase("testcases/FloatDeclarationAndInitialization.js");
        }
        [Test]
        public void ForeachDeclaration()
        {
            this.RunTestCase("testcases/ForeachDeclaration.js");
        }
        [Test]
        public void ForeachItemInArray()
        {
            this.RunTestCase("testcases/ForeachItemInArray.js");
        }
        [Test]
        public void GUIContentInitialization()
        {
            this.RunTestCase("testcases/GUIContentInitialization.js");
        }
        [Test]
        public void GameObjectInitialization()
        {
            this.RunTestCase("testcases/GameObjectInitialization.js");
        }
        [Test]
        public void HashTableInitialization()
        {
            this.RunTestCase("testcases/HashTableInitialization.js");
        }
        [Test]
        public void HideInInspectorTest()
        {
            this.RunTestCase("testcases/HideInInspectorTest.js");
        }
        [Test]
        public void IfBlock()
        {
            this.RunTestCase("testcases/IfBlock.js");
        }
        [Test]
        public void InferredArrayField()
        {
            this.RunTestCase("testcases/InferredArrayField.js");
        }
        [Test]
        public void InstantiateCast()
        {
            this.RunTestCase("testcases/InstantiateCast.js");
        }
        [Test]
        public void JointDriveDeclaration()
        {
            this.RunTestCase("testcases/JointDriveDeclaration.js");
        }
        [Test]
        public void KeyframeInitialization()
        {
            this.RunTestCase("testcases/KeyframeInitialization.js");
        }
        [Test]
        public void MaterialInitialization()
        {
            this.RunTestCase("testcases/MaterialInitialization.js");
        }
        [Test]
        public void MaterialPropertyBlockInitialization()
        {
            this.RunTestCase("testcases/MaterialPropertyBlockInitialization.js");
        }
        [Test]
        public void MeshInitialization()
        {
            this.RunTestCase("testcases/MeshInitialization.js");
        }
        [Test]
        public void MultiplyEqual()
        {
            this.RunTestCase("testcases/MultiplyEqual.js");
        }
        [Test]
        public void MyScript()
        {
            this.RunTestCase("testcases/MyScript.js");
        }
        [Test]
        public void ObjectFindObjectsOfTypeCall()
        {
            this.RunTestCase("testcases/ObjectFindObjectsOfTypeCall.js");
        }
        [Test]
        public void OnMemberExpressionQuotes()
        {
            this.RunTestCase("testcases/OnMemberExpressionQuotes.js");
        }
        [Test]
        public void OnMethodInvocationExpressionQuotes()
        {
            this.RunTestCase("testcases/OnMethodInvocationExpressionQuotes.js");
        }
        [Test]
        public void OneLineIf()
        {
            this.RunTestCase("testcases/OneLineIf.js");
        }
        [Test]
        public void OperationInsideAParam()
        {
            this.RunTestCase("testcases/OperationInsideAParam.js");
        }
        [Test]
        public void OutArgumentCS()
        {
            this.RunTestCase("testcases/OutArgumentCS.js");
        }
        [Test]
        public void QuoteEscaping()
        {
            this.RunTestCase("testcases/QuoteEscaping.js");
        }
        [Test]
        public void RectInitialization()
        {
            this.RunTestCase("testcases/RectInitialization.js");
        }
        [Test]
        public void RefArgumentsCS()
        {
            this.RunTestCase("testcases/RefArgumentsCS.js");
        }
        [Test]
        public void RequireComponentTest()
        {
            this.RunTestCase("testcases/RequireComponentTest.js");
        }
        [Test]
        public void StaticColorCall()
        {
            this.RunTestCase("testcases/StaticColorCall.js");
        }
        [Test]
        public void StringDeclaration()
        {
            this.RunTestCase("testcases/StringDeclaration.js");
        }
        [Test]
        public void TryCatchStatements()
        {
            this.RunTestCase("testcases/TryCatchStatements.js");
        }
        [Test]
        public void TypeInfCollider()
        {
            this.RunTestCase("testcases/TypeInfCollider.js");
        }
        [Test]
        public void TypeofCrash()
        {
            this.RunTestCase("testcases/TypeofCrash.js");
        }
        [Test]
        public void TypeofIF()
        {
            this.RunTestCase("testcases/TypeofIF.js");
        }
        [Test]
        public void TypeofStaticInt()
        {
            this.RunTestCase("testcases/TypeofStaticInt.js");
        }
        [Test]
        public void VarArgsConstructorInvocation()
        {
            this.RunTestCase("testcases/VarArgsConstructorInvocation.js");
        }
        [Test]
        public void VectorInitialization()
        {
            this.RunTestCase("testcases/VectorInitialization.js");
        }
        [Test]
        public void WWWInitialization()
        {
            this.RunTestCase("testcases/WWWInitialization.js");
        }
        [Test]
        public void typeofParams()
        {
            this.RunTestCase("testcases/typeofParams.js");
        }
    }
}
