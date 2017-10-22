# TagHelperNet
Using TagHelperNet to help you develop your projects quickly.

Simple 1: MathJax
```HTML
<import-MathJax config="Recommand"></import-MathJax>
<p>
    When \(a \ne 0\), there are two solutions to \(ax^2 + bx + c = 0\) and they are
    $$x = {-b \pm \sqrt{b^2-4ac} \over 2a}.$$
</p>
```

Simple 2: SyntaxHighlighter
```HTML
<import-SyntaxHighlighter></import-SyntaxHighlighter>

<code np-language="CSharp">
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
    }
}
</code>
```

Simple 3: Bootstrap's modal
```HTML
<bs-modal id="default_modal">
    <-title>Here is a title</-title>
    <-content>
        Here is content
    </-content>
    <-footer>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
    </-footer>
</bs-modal>
<button type="button" data-toggle="modal" data-target="#default_modal">S</button>
```
