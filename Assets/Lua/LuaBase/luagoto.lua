--  togo
local a = 1

goto label1

::label1::
print("--- goto label ---")

i = 0
::s1::
do
    print(i)
    i = i + 1
end
if i > 3 then
    os.exit() -- i 大于 3 时退出
end
-- goto s1

local s, e = string.find("www.runoob.com", "runoob")
print(s, e)

---函数
---@param aaar any
---@return integer
---@return any
local function checkMax(aaar)
    local mi = 1
    local m = aaar[mi]
    for index, value in ipairs(aaar) do
        if value > m then
            mi = index
            m = value
        end
    end
    return mi, m
end

print(checkMax({2, 3, 45, 6, 1}))

-- 加法
local function cacleTotal(arr)
    local s = 0
    for i, value in ipairs(arr) do
        s = value + s
    end
    return s
end

print(cacleTotal({1, 2, 3, 4, 5, 6, 7, 8, 9, 10}), "  ~~~  ")

local function fwrite(fmt, ...)
    return io.write(string.format(fmt, ...))
end

fwrite("s")
fwrite("s", 1, 2, 3, 4)
fwrite("s\n", 1, 2, 3, 4)
fwrite("%d\n", 1, 2)

fwrite("%d%d\n", 1, 2)
fwrite("%d%d\n", 1, 2)
fwrite("%d%d%d\n", 1, 2, 3, 4)

fwrite("%d%d\n", 1, 2, 3, 4)
print("\n\n~~~~~~~~~~~~~~~")
local function ffff(...)
    local a = select(3, ...)
    print(a)
    print(select(3, ...))
end
ffff(0, 1, 2, 3, 4, 5, 6)

print("\n\n~~~~~~~~~~~~~~~")

local function foo(...)
    local len=select("#", ...) 
    for i = 1, len do -->获取参数总数
        local arg = select(i, ...) -->读取参数，arg 对应的是右边变量列表的第一个参数
        print("arg", arg)
    end
end

foo(1, 2, 3, 4)

local a=1
if a~=1 then
    print("df")
end

--逻辑运算符0
if true and false then
    print(false)
end

if true or false then
    print(false," 111")
end

if not(true and false) then
    print(false," 222")
end