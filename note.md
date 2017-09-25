# note

https://yuml.me/diagram/scruffy/class/draw 

// Cool Class Diagram
[ICompiler|-ChildrenCompiler:ICompiler]++-1>[ICompiler|-ChildrenCompiler:ICompiler]

[ICompiler]^-[LazyCompiler]
[ICompiler]^-[EnumrableCompiler]
[ICompiler]^-[ConstructorCompiler] 
