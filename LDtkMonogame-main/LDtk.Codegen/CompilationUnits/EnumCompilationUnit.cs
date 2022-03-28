
using System.Collections.Generic;

namespace LDtk.Codegen.CompilationUnits;
public class EnumCompilationUnit : CompilationUnitFragment
{
    public List<string> Literals { get; set; } = new List<string>();

    public override void Render(CompilationUnitSource source)
    {
        source.AddLine($"public enum {Name}");
        source.StartBlock();

        foreach (string literal in Literals)
        {
            source.AddLine($"{literal},");
        }

        source.EndBlock();
    }
}
