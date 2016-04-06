MvcScaffolding.Mini Package
=========================

1) Pre requisites
----------

-	[Windows Management Framework 4.0](http://www.microsoft.com/en-ie/download/confirmation.aspx?id=40855):  


2) When to use
----------
- Any ASP.NET MVC 4 Projects created in Visual Studio 2012


3) How to install
---
`Install-Package MvcScaffolding.Mini` 

After installing it you are going to get the following commands:

4) After the installation
----------

**addViewModel**

- Ex.: `addViewModel Product`
- Output: a new file: Models\Product.cs

	public class Product
	{
	
	}

**addViewModelWithFields**

- Ex.: `addViewModelWithFields Product`
- Output: a new file: Models\Product.cs

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }   
    }

**addClassProperty**

- Ex.: `addClassProperty Product "string Description"`
- Output: a new property at product class: 

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string Description { get; set; }    // this line
    }

**addClassLine**

- Ex.: `addClassLine Product "// new line of code"`
- Output: 

    public class Product
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Released { get; set; }
    public string Description { get; set; }
    // new line of code
    }

**addController**

- Ex.: `addController Product`
- Output:

	Added database context 'Models\AppContext.cs'
	Added 'Products' to database context 'MvcApplication45.Models.AppContext'
	Added repository 'Models\ProductRepository.cs'
	Added controller Controllers\ProductsController.cs
	Added Create view at 'Views\Products\Create.cshtml'
	Added Edit view at 'Views\Products\Edit.cshtml'
	Added Delete view at 'Views\Products\Delete.cshtml'
	Added Details view at 'Views\Products\Details.cshtml'
	Added Index view at 'Views\Products\Index.cshtml'
	Added _CreateOrEdit view at 'Views\Products\_CreateOrEdit.cshtml'

**addTest**

- Ex.: `addTest Product Products Create`
- Output:

	Added unit test class at ProductsControllerTest.cs
	Added unit test method CreateTest to ProductsControllerTest

**addAllTests**

- Ex.: `addAllTests Product Products`
- Output:

	Added unit test class at ProductsControllerTest.cs
	Added unit test method IndexTest to ProductsControllerTest
	Added unit test method CreateTest to ProductsControllerTest
	Added unit test method DetailsTest to ProductsControllerTest
	Added unit test method DeleteTest to ProductsControllerTest
	Added unit test method EditTest to ProductsControllerTest
