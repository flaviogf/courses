using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Section10.GeneratingCode
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var employeConstructor = new CodeConstructor();
            var nameParameter = new CodeParameterDeclarationExpression(typeof(string), "name");
            var salaryParameter = new CodeParameterDeclarationExpression(typeof(int), "salary");
            var nameAssignStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("Name"), new CodeVariableReferenceExpression("name"));
            var salaryAssingStatement = new CodeAssignStatement(new CodeVariableReferenceExpression("Salary"), new CodeVariableReferenceExpression("salary"));
            employeConstructor.Attributes = MemberAttributes.Public;
            employeConstructor.Parameters.Add(nameParameter);
            employeConstructor.Parameters.Add(salaryParameter);
            employeConstructor.Statements.Add(nameAssignStatement);
            employeConstructor.Statements.Add(salaryAssingStatement);

            var employeClass = new CodeTypeDeclaration("Employe");
            var nameMemberField = new CodeMemberField(typeof(string), "Name");
            var salaryMemberField = new CodeMemberField(typeof(int), "Salary");
            salaryMemberField.Attributes = MemberAttributes.Public;
            nameMemberField.Attributes = MemberAttributes.Public;
            employeClass.Members.Add(employeConstructor);
            employeClass.Members.Add(nameMemberField);
            employeClass.Members.Add(salaryMemberField);

            var codeNamespace = new CodeNamespace("Section10.GeneratingCode");
            var systemImport = new CodeNamespaceImport("System");
            codeNamespace.Imports.Add(systemImport);
            codeNamespace.Types.Add(employeClass);

            var unit = new CodeCompileUnit();
            unit.Namespaces.Add(codeNamespace);

            using var codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
            using var file = new StreamWriter("Employe.cs");
            codeDomProvider.GenerateCodeFromCompileUnit(unit, file, null);

            Console.WriteLine("File was generated.");

            var employe = new Employe("Fernando", 100000);
            Console.WriteLine(employe.Name);
            Console.WriteLine(employe.Salary);
        }
    }
}
