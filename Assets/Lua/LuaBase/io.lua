local file=io.open("test.lua","r")
io.input(file)
print(io.read())
io.close(file)

-----
file = io.open("test.lua", "a")
io.output(file)
io.write("\n--  test.lua 文件末尾注释")
io.close(file)

file=io.open("test.lua","r")
print(file:read())
file:close()

file=io.open("test.lua","a")
file:write("...mowei ")
file:close()


file=io.open("test.lua","r")
file:seek("end",-10)
print(file:read("*a"))
file:close()


print(collectgarbage("count"))

local mytbale1={"111","222","333"}

print(collectgarbage("count"))
mytbale1 =nil
collectgarbage("collect")
print(collectgarbage("count"))



-- 元类
Shape = {area = 0}

-- 基础类方法 new
function Shape:new (o,side)
  o = o or {}
  setmetatable(o, self)
  self.__index = self
  side = side or 0
  self.area = side*side;
  return o
end

-- 基础类方法 printArea
function Shape:printArea ()
  print("面积为 ",self.area)
end

-- 创建对象
myshape = Shape:new(nil,10)

myshape:printArea()
