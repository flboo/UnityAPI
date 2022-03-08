print("Hello World！")

print("www.runoob.com")

print(type("sd"))
print(type(1))

print(type(false))
print(type(true))
print(type(boolean))
print(type(bool))
print(type(print))
print(type(nil))
print(type(x))
print(type(type(x)))

local tab1 = {key1 = "12", key2 = "k2", "k3"}
for k, v in pairs(tab1) do
    print(k .. " - " .. v)
end

tab1.key2 = nil

for k, v in pairs(tab1) do
    print(k .. " - " .. v)
end

print(type(false))
print(type(true))
print(type(nil))
print(type(0))

if true or "nil" == type(nil) then
    print("2222")
    print("2222")
end

--计算字符串的长度
local length = "asdfsdx"
print(#length)

---=
---
print("-2e2" * "6")
print(2e2 * 6)

local testtable = {"qwedfd", "ewrf", "2"}

for index, value in ipairs(testtable) do
    print("key " .. index .. "  " .. value)
end

for key, value in pairs(testtable) do
    print("key value " .. key .. "  " .. value)
end

local function factorial1(n)
    if n == 0 then
        print("n==0")
        return 1
    else
        print("n==11")
        return n * factorial1(n - 1)
    end
end

print(factorial1(3))

local function fffff()
    return 1, 2
end

local a1111, b1111 = fffff()

print(a1111 .. "  " .. b1111)

local site = {}
site["key"] = "www.runoob.com"
print(site["key"])

print(site.key .. " ~~~````~~~~~~~~~~~~~~~~~~~")

----匿名函数
local function testFun(tab, fun)
    for key, value in pairs(tab) do
        print(fun(key, value))
    end
end

local tab = {key1 = "wef", key2 = "wf", key3 = "sdfg123"}

testFun(
    tab,
    function(key, value)
        return key .. "=" .. value
    end
)
