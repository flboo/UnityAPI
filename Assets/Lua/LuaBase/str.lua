--字符串串

local string1="lua"
print("\"字符串1是\"",string1)

local string2="runbbo"
print("字符串2是",string2)

local string3=[["rooboo"]]
print("字符串3是",string3)

--转义字符
local string4="roobootest"
print("111\n222")
print("111\a222")
print("333\b444")
print("5555\f666")
print("66666\r77777")
print("7777\v8888")
print("~~~~~~~~~~")
print("88888\\999999")
print("88888/999999")
print("88888//999999")

print("88888\'999999")
print("88888\"999999")


print("88888\0999999")



io.write("\n\"")
local string5="abcdefg"
local length=string.len(string5)
print(string.rep(string5,3),"  length : ",length)


print(string.gsub("hello, up-down!", "%A", "."))
print(string.gsub("hello, up-down!", ".", "."))

local array={"googl=e","baidu"}

local function elementIterator(collect)
    local index=0
    local count=#collect;
    return function ()
        index=index+1
        if index<=count then
            return collect[index]
        end
    end
end

local values= elementIterator(array);

for element in values do
    print(element)
end


--table  
local fruits = {"banana","orange","apple"}
print("table.contat: ",table.concat(fruits))
print("table.contat: ",table.concat(fruits,", ,"))
print("table.contat: ",table.concat(fruits,", ,",1,2))
print("table.contat: ",table.concat(fruits,", ,",1,1))
print("table.contat: ",table.concat(fruits,", ,",2,2))
print("table.contat: ",table.concat(fruits,",",2,3))

table.insert(fruits,1,"222")
print("table.contat: ",table.concat(fruits,","))

local function table_pack(param, ...)
    local arg = table.pack(param,...)
    print("this arg table length is", arg.n)
    for i = 1, arg.n do
        print(i, arg[i])
    end
end
 
table_pack("test", "param1", "param2", "param3")
