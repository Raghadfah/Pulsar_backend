using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using AutoMapper;

namespace sda_onsite_2_csharp_backend_teamwork.src.Service;

    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderItemReadDto> FindAll()
        {
            var orderItems = _orderItemRepository.FindAll();
            var orderItemsRead = orderItems.Select(_mapper.Map<OrderItemReadDto>);
            return orderItemsRead;
        }


        public OrderItemReadDto? FindOne (Guid id)
        {

            OrderItem ? orderItem =_orderItemRepository.FindOne(id);
            OrderItemReadDto? orderItemRead =_mapper.Map<OrderItemReadDto>(orderItem);
            return orderItemRead;
        }

        public OrderItemReadDto CreateOne(OrderItemReadDto OrderItem)

        {
            var newOrderItem=_mapper.Map<OrderItem>(OrderItem);
            var createdOrderItem = _orderItemRepository.CreateOne(newOrderItem);
            var createdOrderItemRead = _mapper.Map<OrderItemReadDto>(createdOrderItem);
            return createdOrderItemRead;
        }

        public OrderItemReadDto? UpdateOne(Guid id, OrderItem orderItem)
        {
            var updatOrderItem = _orderItemRepository.FindOne(id);
            if (updatOrderItem != null)
            {
                updatOrderItem.Quantity = orderItem.Quantity;
                var updatedOrderItemAllInfo = _orderItemRepository.UpdateOne(updatOrderItem);
                var updatedOrderItemRead = _mapper.Map<OrderItemReadDto>(updatedOrderItemAllInfo);
                return updatedOrderItemRead;
            }
            else return null;
            
        }

        public bool DeleteOne(Guid id)
        {
            return _orderItemRepository.DeleteOne(id);
        }
    }


