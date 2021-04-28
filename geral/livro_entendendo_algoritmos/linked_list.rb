class Node
    attr_accessor :value, :after

    def initialize(value, after)
        @value = value
        @after = after
    end
end

class LinkedList
    attr_accessor :head

    def prepend(value)
        @head = Node.new(value, @head)
    end

    def append(value)
        if @head == nil
            @head = Node.new(value, nil)
        end

        current = @head

        while current.after != nil
            current = current.after
        end

        current.after = Node.new(value, nil)
    end

    def remove(value)
        if @head == nil
            return
        end

        if @head.value = value
            @head = @head.after
        end

        current = @head

        while current.after != nil
            if current.after.value == value
                current.after = current.after.after
                return
            end

            current = current.after
        end
    end
end

def main()
    list = LinkedList.new

    list.prepend 10

    list.prepend 20

    list.prepend 30

    list.append 40

    list.append 50

    list.remove 20

    list.remove 30

    list.remove 10

    print list
end

def print(list)
    current = list.head

    while current != nil
        puts current.value

        current = current.after
    end
end

main
