module1={}
module1.costant="这是一个常量"
function module1.fucn1()
    io.write("这个一个globe方法、\n");
end

local function func2()
   print("local  方法")
end

function module1.func3()
    func2()
end
return module1;

