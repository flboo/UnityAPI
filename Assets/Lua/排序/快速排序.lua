function QuickSort(array,left,right)
	if(left<right) then
		local x = array[left]
		local i = left
		local j = right
		while(i<j) do
			while(i<j) do
				if(array[j] <x) then
					array[i] = array[j]
					break
				else
					j = j-1
				end
			end
			while(i<j) do
				if(array[i] > x) then
					array[j] = array[i]
					break
				else
					i = i+1
				end
			end
		end
		array[i] = x;
		QuickSort(array,left,i-1)
		QuickSort(array,i+1,right)
	end
end
--array1����
local array1 = {73,23,18,92}
QuickSort(array1, 1,#array1)
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



