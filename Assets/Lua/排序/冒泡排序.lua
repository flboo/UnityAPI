function BubbleSort(array)
	for i = 1,#array-1 do
		for j = i+1,#array do
			if(array[i]>array[j]) then
				local temp = array[i]
				array[i] = array[j]
				array[j] = temp
			end
		end
	end
	return array
end
--array1����
local array1 = {73,23,18,92}
BubbleSort(array1, 1,#array1)
--array2����
array2 = {73,23,18,92}
table.sort(array2)
--array1�������
print("array1�������")
for k,v in pairs(array1) do
	print(v)
end
--array2�������
print("array2�������")
for k,v in pairs(array2) do
	print(v)
end
