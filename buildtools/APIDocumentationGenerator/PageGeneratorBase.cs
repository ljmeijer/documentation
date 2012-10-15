namespace APIDocumentationGenerator2
{
	internal class PageGeneratorBase
	{
		protected static string PageHeader()
		{
			return @"<!DOCTYPE html>
<html>
  <head>
    <meta charset='utf-8' />
    <link href='docs.css' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans+Mono' rel='stylesheet' type='text/css'>
    <title>UnityEngine.GameObject</title>
  </head>
  <body class=''>
    <header>
      <div class='container'>
        <nav>
          <a href='/commands'>MenuItem1</a>
          <a href='/clients'>MenuItem2</a>
          <a href='/documentation'>MenuItem3</a>
          <a href='/community'>MenuItem4</a>
          <a href='/download'>MenuItem5</a>
        </nav>
      </div>
    </header>
";
		}
	}
}