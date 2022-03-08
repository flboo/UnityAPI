Person = { name = "LiuDeHua", age = 56 }
function Person:eat()
    print(self.age .. "��" .. self.name .. "�ڳԷ�")
end

function Person:new(o)
    local t = o or {}
    setmetatable(t, { __index = self })
    return t
end

Person_1 = Person:new({ name = "ZhangXueYou" })
Person_1:eat()
